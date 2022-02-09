using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickDetector : MonoBehaviour
{
    void OnMouseDown()
    {
        var renderer = GetComponent<Renderer>();
        if (renderer.material.GetColor("_Color") != Color.red) {
            renderer.material.SetColor("_Color", Color.red);
        } else {
            renderer.material.SetColor("_Color", Color.blue);
        }
        
        Debug.Log("Mouse down");
    }
}
