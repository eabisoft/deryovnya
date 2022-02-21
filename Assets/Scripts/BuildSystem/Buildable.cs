using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour
{
    public bool collides = false;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer != LayerMask.NameToLayer("Ground"))
            collides = true;
    }

    private void OnCollisionStay(Collision other) {
        if (other.gameObject.layer != LayerMask.NameToLayer("Ground"))
            collides = true;
    }

    private void OnCollisionExit(Collision other) {
        collides = false;
    }

    public bool CanBePlaced() {
        return !collides;
    }

}
    