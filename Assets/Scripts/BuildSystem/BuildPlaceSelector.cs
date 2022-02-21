using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlaceSelector : MonoBehaviour
{
    private const float MAX_RAY_DISTANCE = 50f;
    private Vector3 coordinates;
    void Start() {
        
    }

    void Update() {
        DrawLine();
        ReplacePattern();
        ColorBuildable();
        if (Input.GetMouseButton(0)) {
            OnBuild();
        }
    }

    private void ColorBuildable() {
        var renderer = GetComponent<Renderer>();
        renderer.material.shader = Shader.Find("Transparent/Diffuse");
        renderer.material.color = Color.red * 0.5f;
        if (GetComponent<Buildable>().CanBePlaced()) {
            renderer.material.color = Color.blue * 0.5f;
        }
    }

    private void ReplacePattern() {
        transform.position = coordinates;
        // TODO выравнивание по высоте 
    }

    private void OnBuild() {
        var renderer = GetComponent<Renderer>();
        if (coordinates != null) {
            if (BuildManager.currentBuilding == null || 
                !BuildManager.currentBuilding.Equals(this.gameObject)
            ) {
                Debug.LogError("BuildManager.currentBuilding null");
                Destroy(this.gameObject);
            }
            
            if (GetComponent<Buildable>().CanBePlaced()) {
                // TODO Добавление нужных компонентов строящемуся объекту
                // Ну там не обязательно цвет белый был по итогу, переделать потом
                renderer.material.SetColor("_Color", Color.white);
                
                Destroy(this.GetComponent<BuildPlaceSelector>());
                BuildManager.ClearCurrentBuildingIfEqual(this.gameObject);
            }
        }
    }

    private void DrawLine() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int groundMask = LayerMask.GetMask("Ground");
        if (Physics.Raycast(ray, out RaycastHit hitInfo, MAX_RAY_DISTANCE, groundMask)) {
            coordinates = hitInfo.point;
        }
    }
}
