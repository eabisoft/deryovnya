using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    
    float zoomSpeed = 5f;

    float maxHeight = 15f;
    float minHeight = 5f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float scrollslp = zoomSpeed * Input.GetAxis("Mouse ScrollWheel");


        Vector3 verticalMove = transform.forward * scrollslp;
        

        Vector3 move = verticalMove;
        transform.position += move;
        
        
            
    }
}
