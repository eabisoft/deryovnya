using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlaceSelector : MonoBehaviour
{
    private const float MAX_RAY_DISTANCE = 50f;
    private Vector3 coordinates;
    private Rigidbody rb;
    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        DrawLine();
        ReplacePattern();
        if (Input.GetMouseButton(0))
        {
            OnBuild();
        }
    }

    public void ColorBuildable() {
        var renderer = GetComponent<Renderer>();
        renderer.material.shader = Shader.Find( "Transparent/Diffuse" );
        renderer.material.color = Color.red * 0.5f;
        if (BuildManager.currentBuilding.GetComponent<Buildable>().CanBePlaced()) {
            renderer.material.color = Color.blue * 0.5f;
        }
    }
    
    private void ReplacePattern() {
        //Поднял объекты чиста по приколу, коллизии считаются со всех сторон, так что наверное надо будет на микрописю
        //левитировать наши кубы
        //Хотя у нас есть тег для земли...
        // coordinates.y = 3f;
        //Эту хрень на всякий запихнул, чтобы объект при столкновении не вращался, как ебанутый
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        BuildManager.currentBuilding.transform.position = coordinates;
        ColorBuildable();
        // TODO выравнивание по высоте 
    }

    private void OnBuild() {
        var renderer = GetComponent<Renderer>();
        if (coordinates != null) {
            var building = BuildManager.currentBuilding;
            if (building == null)
                Debug.LogError("BuildManager.currentBuilding null");
            
            if (building.GetComponent<Buildable>().CanBePlaced()) {
                // TODO Добавление нужных компонентов строящемуся объекту
                // Этот кусок наверное можно запихнуть куда-то еще, но мне показалось, что сюда норм
                rb.constraints = RigidbodyConstraints.FreezeAll;
                renderer.material.SetColor("_Color", Color.white);
                // ы
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
