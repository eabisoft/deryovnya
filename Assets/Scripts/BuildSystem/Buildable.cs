using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour
{
    public Resource resourceTypeToCollide = Resource.None;
    [Range(0f, 180f)]
    public float maxTiltAngle = 0;
    public ResourcesDictionary buildCost;
    private bool isNotCollides = true;
    private bool isCollidesWithResourse = false;
    
    private void collisionCheck(Collision other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Resource")) {
            if (other.gameObject.GetComponent<ResourceSource>().type == resourceTypeToCollide)
                isCollidesWithResourse = true;
            else 
                isNotCollides = false;
        } else if (other.gameObject.layer != LayerMask.NameToLayer("Ground")) {
            isNotCollides = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        collisionCheck(other);
    }

    private void OnCollisionStay(Collision other) {
        collisionCheck(other);
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Resource")) {
            if (other.gameObject.GetComponent<ResourceSource>().type == resourceTypeToCollide)
                isCollidesWithResourse = false;
            else 
                isNotCollides = true;
        } else if (other.gameObject.layer != LayerMask.NameToLayer("Ground")) {
            isNotCollides = true;
        }
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
        return isNotCollides // Проверка отсутвия коллизий с другими игровыми объектами
        && TiltAngelInRange() // Проверка нахождения в пределах угла наклона
        && (resourceTypeToCollide == Resource.None || isCollidesWithResourse); // Проверка наличия ресурса при его необходимости
    }

}
