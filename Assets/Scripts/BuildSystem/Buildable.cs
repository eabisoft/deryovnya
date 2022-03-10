using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour
{
    private bool collides = false;

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
        // they are in the range [0,360]
        var angles = transform.rotation.eulerAngles;
        
        // TODO add an inaccurate comparison using some delta
        return (angles.x <= maxTiltAngle || angles.x >= (360f - maxTiltAngle))
            && (angles.y <= maxTiltAngle || angles.y >= (360f - maxTiltAngle))
            && (angles.z <= maxTiltAngle || angles.z >= (360f - maxTiltAngle));
    }

    public bool CanBePlaced() {
        return !collides && TiltAngelInRange();
    }

}
