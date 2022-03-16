using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiInfo : MonoBehaviour
{
    [SerializeField] private Text myText;

    void Update()
    {
        myText.text = "Food: " + ResourcesManager.Resources[Resource.Food] + 
            "\nTree: " + ResourcesManager.Resources[Resource.Tree] + 
            "\nStone: " + ResourcesManager.Resources[Resource.Stone];
    }
}
