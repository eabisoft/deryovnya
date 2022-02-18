using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlaceSelector : MonoBehaviour
{
    private const float MAX_RAY_DISTANCE = 50f;
    private Vector3 coordinates;

    void Update()
    {
        DrawLine();
        ReplacePattern();
        if (Input.GetMouseButton(0))
        {
            OnBuild();
        }
    }
    
    private void ReplacePattern() {
        BuildManager.currentBuilding.transform.position = coordinates;
        // TODO выравнивание по высоте 
    }

    private void OnBuild() {
        if (coordinates != null) {
            var building = BuildManager.currentBuilding;
            if (building == null)
                Debug.LogError("BuildManager.currentBuilding null");
            
            if (building.GetComponent<Buildable>().CanBePlaced()) {
                // TODO Добавление нужных компонентов строящемуся объекту
                Destroy(this.GetComponent<BuildPlaceSelector>());
                BuildManager.ClearCurrentBuildingIfEqual(this.gameObject);
            }
        }
    }

    private void DrawLine() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hits = Physics.RaycastAll(ray, MAX_RAY_DISTANCE);
        foreach (var hit in hits)
        {
            if (hit.collider.tag == "Ground") {
                // Debug.Log("Foind!");
                coordinates = hit.point;
            }
        }
    }
}
