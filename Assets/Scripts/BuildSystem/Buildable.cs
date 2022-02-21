using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour
{
    public bool collides = false;


    private void OnCollisionEnter(Collision other) {
        collides = true;
    }

    private void OnCollisionStay(Collision other) {
        collides = true;
    }

    private void OnCollisionExit(Collision other) {
        collides = false;
    }

    public bool CanBePlaced() {
        if (collides == true){
            return false;
        }
        else {
            return true;
        }
    }

}


    