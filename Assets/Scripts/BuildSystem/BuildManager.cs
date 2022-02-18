using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildManager : ScriptableSingleton<BuildManager>
{
    static private GameObject _currentBuilding;

    static public GameObject currentBuilding 
    {
        get {return _currentBuilding; }
    }

    static public void ChangeCurrentBuilding(GameObject newBuilding) {
        // addtitonal logic here
        _currentBuilding = Instantiate(newBuilding);
        _currentBuilding.AddComponent<BuildPlaceSelector>();
    }

    static public void ClearCurrentBuildingIfEqual(GameObject gameObject) {
        if (_currentBuilding.Equals(gameObject)) {
            _currentBuilding = null;
        }
    }

}
