using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildPlaceSelector : MonoBehaviour
{
    private const float MAX_RAY_DISTANCE = 50f;
    private bool hasSurfaceHit = false;
    private Vector3 coordinates;
    private Vector3 surfaceNormal;
    private Quaternion surfaceRotation;
    private Material defaultMaterial;

    void Start() {
        defaultMaterial = GetComponent<Renderer>().sharedMaterial;
        GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Diffuse");
    }

    void Update() {
        RaycastToSurface();
        ReplaceBuildable();
        ColorBuildable();
        if (Input.GetKey(KeyCode.Escape)){
            BuildManager.CancelBuild(this.gameObject);
        }
        if (Input.GetMouseButton(0)) {
            OnBuild();
        }
    }

    private void ColorBuildable() {
        var highlightColor = Color.red * 0.5f;
        if (GetComponent<Buildable>().CanBePlaced() && hasSurfaceHit) {
            highlightColor = Color.blue * 0.5f;
        }
        GetComponent<Renderer>().material.color = highlightColor;
    }

    private void ReplaceBuildable() {
        transform.rotation = surfaceRotation;
        Vector3 heightFix = surfaceNormal * GetComponent<MeshFilter>().mesh.bounds.size.y / 2;
        transform.position = coordinates + heightFix;
    }

    private void OnBuild() {
        var renderer = GetComponent<Renderer>();
        if (hasSurfaceHit) {
            if (!BuildManager.currentBuilding.Equals(this.gameObject)) {
                BuildManager.CancelBuild(this.gameObject);
            }
            
            if (GetComponent<Buildable>().CanBePlaced()) {
                // TODO Добавление нужных компонентов строящемуся объекту
                renderer.material = defaultMaterial;
                
                Destroy(this.GetComponent<BuildPlaceSelector>());
                BuildManager.Build(this.gameObject);
            }
        }
    }

    private void RaycastToSurface() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int groundMask = LayerMask.GetMask("Ground");
        hasSurfaceHit = Physics.Raycast(ray, out RaycastHit hit, MAX_RAY_DISTANCE, groundMask); 
        if (hasSurfaceHit) {
            // https://docs.unity3d.com/ScriptReference/RaycastHit-triangleIndex.html
            // Получаем координаты вершин теугольника, в который мы попали
            MeshCollider meshCollider = hit.collider as MeshCollider;
            Mesh mesh = meshCollider.sharedMesh;
            Vector3[] vertices = mesh.vertices;
            int[] triangles = mesh.triangles;
            Vector3 p0 = vertices[triangles[hit.triangleIndex * 3 + 0]];
            Vector3 p1 = vertices[triangles[hit.triangleIndex * 3 + 1]];
            Vector3 p2 = vertices[triangles[hit.triangleIndex * 3 + 2]];
            Transform hitTransform = hit.collider.transform;
            p0 = hitTransform.TransformPoint(p0);
            p1 = hitTransform.TransformPoint(p1);
            p2 = hitTransform.TransformPoint(p2);

            // https://docs.unity3d.com/2019.3/Documentation/Manual/ComputingNormalPerpendicularVector.html
            // На основе вершин высчитываем нормаль и нормализуем ее
            surfaceNormal = Vector3.Normalize(Vector3.Cross(p1 - p0, p2 - p0));

            // С помощью нормали получаем квантерион поворота
            surfaceRotation = Quaternion.FromToRotation(Vector3.up, surfaceNormal);
            
            coordinates = hit.point;
        }
    }
}
