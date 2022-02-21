using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigScript : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float rotationSpeed = 90f;
    const float FRAME_OFFSET = 5f; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        // MoveByFrame();
        Rotate();
    }

    void Move()
    {
        float hsp = moveSpeed * Input.GetAxis("Horizontal");
        float vsp = moveSpeed * Input.GetAxis("Vertical");

        Vector3 lateralMove = hsp * transform.right;
        Vector3 forwardMove = transform.forward;
        forwardMove.y = 0;
        forwardMove.Normalize();
        forwardMove *= vsp;

        Vector3 move = (lateralMove + forwardMove) * Time.deltaTime;

        transform.position += move;
    }

    // void MoveByFrame()
    // {
    //     Vector3 mForw = transform.forward;
    //     mForw.y = 0;
    //     mForw.Normalize();
    //     mForw *= moveSpeed * Time.deltaTime;

    //     Vector3 mRight = transform.right;
    //     mRight.y = 0;
    //     mRight.Normalize();
    //     mRight *= moveSpeed * Time.deltaTime;
        
    //     if (Input.mousePosition.x >= Screen.width - FRAME_OFFSET)
    //         transform.position += mRight;
    //     else if (Input.mousePosition.x <= FRAME_OFFSET)
    //         transform.position -= mRight;

    //     if (Input.mousePosition.y >= Screen.height - FRAME_OFFSET)
    //         transform.position += mForw;
    //     else if (Input.mousePosition.y <= FRAME_OFFSET)
    //         transform.position -= mForw;
    // }

    void Rotate()
    {
        Vector3 rotation = Vector3.zero;

        if (Input.GetKey(KeyCode.Q))
            rotation = Vector3.up;
        else if (Input.GetKey(KeyCode.E))
            rotation = Vector3.down;

        rotation *= Time.deltaTime * rotationSpeed;

        transform.Rotate(rotation);
    }
}
