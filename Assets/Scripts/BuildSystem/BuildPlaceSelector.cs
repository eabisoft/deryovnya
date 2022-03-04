using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlaceSelector : MonoBehaviour
{
    private const float MAX_RAY_DISTANCE = 50f;
    private bool hasSurfaceHit = false;
    private Vector3 coordinates;
    private Vector3 surfaceNormal;
    private Quaternion surfaceRotation;

    void Start() {
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
                // Ну там не обязательно цвет белый был по итогу, переделать потом
                renderer.material.SetColor("_Color", Color.white);
                
                Destroy(this.GetComponent<BuildPlaceSelector>());
                BuildManager.Build(this.gameObject);
            }
        }
    }

    private void RaycastToSurface() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int groundMask = LayerMask.GetMask("Ground");
        hasSurfaceHit = Physics.Raycast(ray, out RaycastHit hitInfo, MAX_RAY_DISTANCE, groundMask); 
        if (hasSurfaceHit) {
            coordinates = hitInfo.point;
            surfaceNormal = hitInfo.normal;
            surfaceRotation = hitInfo.collider.transform.rotation;
        }
    }
}
