using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour
{
    [SerializeField]
    private bool needsResPlace = false;

    [SerializeField]
    private bool collides = false;

    [Range(0f, 180f)]
    public float maxTiltAngle = 0;

    public ResourcesDictionary buildCost;

    private void OnCollisionEnter(Collision other) {
        if (needsResPlace == true && other.gameObject.layer == LayerMask.NameToLayer("Resource"))
            collides = false;
        else if (needsResPlace == false && other.gameObject.layer != LayerMask.NameToLayer("Ground"))
            collides = true;
    }

    private void OnCollisionStay(Collision other) {
        if (needsResPlace == true && other.gameObject.layer == LayerMask.NameToLayer("Resource"))
            collides = false;
        else if (needsResPlace == false && other.gameObject.layer != LayerMask.NameToLayer("Ground"))
            collides = true;
    }

    private void OnCollisionExit(Collision other) {
        if (needsResPlace == true) 
            collides = true;
        else 
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
