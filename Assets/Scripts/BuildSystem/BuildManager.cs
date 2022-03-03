using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildManager : ScriptableSingleton<BuildManager>
{
    static public GameObject _currentBuilding;
    static public GameObject layout = GameObject.Find("BuildPanel");

    static public GameObject currentBuilding 
    {
        get {return _currentBuilding; }
    }

    void start() {

    }

    static public void ChangeCurrentBuilding(GameObject newBuilding) {
        // addtitonal logic here
        if (_currentBuilding != null)  
            Destroy(_currentBuilding);

        _currentBuilding = Instantiate(newBuilding);
        _currentBuilding.AddComponent<BuildPlaceSelector>();
        layout.gameObject.SetActive(false);
    }

    static public void ClearCurrentBuildingIfEqual(GameObject gameObject) {
        layout.gameObject.SetActive(true);
        if (_currentBuilding.Equals(gameObject)) {
            _currentBuilding = null;
        }
    }

}
