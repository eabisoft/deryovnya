using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    
    float zoomSpeed = 50f;

    float maxHeight = 15f;
    float minHeight = 5f;


    void Zoom() {
        float scrollslp = zoomSpeed * Input.GetAxis("Mouse ScrollWheel");
        Vector3 verticalMove = transform.forward * scrollslp;
        Vector3 move = verticalMove;
        if (transform.position.y == minHeight || transform.position.y == maxHeight){
            move.x = 0;
            move.z = 0;
        }
        
        transform.position += move;
    }

    void Limiter() {
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minHeight, maxHeight);
        transform.position = pos;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Zoom();
        Limiter();



        
            
    }
}


    