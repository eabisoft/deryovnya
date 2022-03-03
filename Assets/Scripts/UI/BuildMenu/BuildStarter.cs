using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildStarter : MonoBehaviour
{
    public GameObject target;

    public void StartBuild() {
        BuildManager.ChangeCurrentBuilding(target);
    }

}
