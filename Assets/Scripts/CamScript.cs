using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public float zoomSpeed = 5f;
    public float maxHeight = 15f;
    public float minHeight = 5f;

    private void Zoom() {
        float scrollslp = zoomSpeed * Input.GetAxis("Mouse ScrollWheel");
        Vector3 verticalMove = transform.forward * scrollslp;
        Vector3 move = verticalMove;
        if (transform.position.y == minHeight || transform.position.y == maxHeight){
            move.x = 0;
            move.z = 0;
        }
        
        transform.position += move;
    }

    private void Limiter() {
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minHeight, maxHeight);
        transform.position = pos;
    }
    
    void Start() {
        //Мб потом отдельный файл для настроек сделаем и туда эту шнягу запихнем
        Application.targetFrameRate = 60;
    }

    void Update() {
        Zoom();
        Limiter();
    }
}
    