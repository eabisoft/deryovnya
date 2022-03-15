using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildProcess : MonoBehaviour
{
    // TODO move to basic build class?
    public int buildTicks = 10 * 10;
    private Vector3 offset;
    private float elapsedTicks;

    void Start()
    {
        offset = new Vector3(0, GetComponent<MeshFilter>().mesh.bounds.size.y, 0);
        transform.Translate(-offset);
    }

    void OnBuild() {
        gameObject.AddComponent<IncomeProcess>();
        Destroy(GetComponent<BuildProcess>());
    }

    void FixedUpdate() {
        elapsedTicks++;
        transform.Translate(offset / buildTicks);
        if (buildTicks == elapsedTicks) {
            OnBuild();
        }
    }
}
