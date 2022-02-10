using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    float speed = 0.05f;
    float zoomSpeed = 5f;
    float rotateSpeed;

    float maxHeight = 15f;
    float minHeight = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hsp = speed * Input.GetAxis("Horizontal");
        float vsp = speed * Input.GetAxis("Vertical");
        float scrollslp = zoomSpeed * (-Input.GetAxis("Mouse ScrollWheel"));

        Vector3 verticalMove = new Vector3(0, scrollslp, 0);
        Vector3 lateralMove = hsp * transform.right;
        Vector3 forwardMove = transform.forward;
        forwardMove.y = 0;
        forwardMove.Normalize();
        forwardMove *= vsp;

        Vector3 move = verticalMove + lateralMove + forwardMove;

        transform.position += move;
    }
}
