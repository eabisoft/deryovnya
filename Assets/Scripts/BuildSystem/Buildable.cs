using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour
{
    private bool collides = false;

    // TODO see TiltAngelInRange 
    [Range(0f, 180f)]
    public float maxTiltAngle = 0;


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

    private bool TiltAngelInRange() {
        var angles = transform.rotation.eulerAngles;
        // TODO The eulerAngles range must be checked
        // I assume that they are in the range [-180,180]
        
        // TODO add an inaccurate comparison using some delta
        return angles.x <= maxTiltAngle && angles.x >= -maxTiltAngle
            && angles.y <= maxTiltAngle && angles.y >= -maxTiltAngle
            && angles.z <= maxTiltAngle && angles.z >= -maxTiltAngle;
    }

    public bool CanBePlaced() {
        return !collides && TiltAngelInRange();
    }

    

}
