using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigScript : MonoBehaviour
{

    float speed = 0.05f;
    float rotateAmount = 0.5f;
    float rotateTime = 0.01f;
    Quaternion newRotation;

    // Start is called before the first frame update
    void Start()
    {
        newRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float hsp = speed * Input.GetAxis("Horizontal");
        float vsp = speed * Input.GetAxis("Vertical");

        Vector3 lateralMove = hsp * transform.right;
        Vector3 forwardMove = transform.forward;
        forwardMove.y = 0;
        forwardMove.Normalize();
        forwardMove *= vsp;

        Vector3 move = lateralMove + forwardMove;

        transform.position += move;


        Vector3 mForw = transform.forward;
        mForw.y = 0;
        mForw.Normalize();
        mForw *= speed;

        Vector3 mRight = transform.right;
        mRight.y = 0;
        mRight.Normalize();
        mRight *= speed;
         
        if (Input.mousePosition.x >= Screen.width - 5f)
            transform.position += mRight;
        if (Input.mousePosition.x <= 5f)
            transform.position -= mRight;
        if (Input.mousePosition.y >= Screen.height - 5f)
            transform.position += mForw;
        if (Input.mousePosition.y <= 5f)
            transform.position -= mForw;
        

        if (Input.GetKey(KeyCode.Q)){
            newRotation *= Quaternion.Euler(Vector3.up * rotateAmount);
        }
        if (Input.GetKey(KeyCode.E)){
            newRotation *= Quaternion.Euler(Vector3.up * -rotateAmount);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotateTime);
    }
}
