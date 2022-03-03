using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildStarter : MonoBehaviour
{
    public GameObject target;
    
    public GameObject kal;
    public GameObject layout;

    
    public void StartBuild() {
        BuildManager.ChangeCurrentBuilding(target);
        // layout.gameObject.SetActive(false);
    }

    // public void ReturnUI() {
    //     layout.gameObject.SetActive(true);
    // }

    
}
