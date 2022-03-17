using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : ScriptableObject
{
    static private GameObject _currentBuilding;
    static public GameObject layout = GameObject.Find("BuildPanel");

    static public GameObject currentBuilding 
    {
        get {return _currentBuilding; }
    }

    static public void ChangeCurrentBuilding(GameObject newBuilding) {
        // addtitonal logic here
        if (_currentBuilding != null)  
            Destroy(_currentBuilding);

        _currentBuilding = Instantiate(newBuilding);
        _currentBuilding.AddComponent<BuildPlaceSelector>();
        layout.SetActive(false);
    }

    static public void CancelBuild(GameObject gameObject) {
        if (gameObject == _currentBuilding) {
            _currentBuilding = null;
            layout.SetActive(true);
        }
        // Additional logic here
        Destroy(gameObject);
    }

    static public void Build(GameObject gameObject) {
        if (!ResourcesManager.Decrease(gameObject.GetComponent<Buildable>().buildCost.Clone())){
            CancelBuild(currentBuilding);
        }
        else if (gameObject == _currentBuilding) {
            _currentBuilding = null;
            layout.SetActive(true);
        }
        

        gameObject.AddComponent<BuildProcess>();
        // Additional logic here
    }

}
