using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuManager : ScriptableSingleton<BuildManager>
{
    private static GameObject activeMenu = null;
    public static void ChangeActiveMenu(GameObject selectedMenu) {
        if (activeMenu != null){
            activeMenu.SetActive(false);
        }
        
        if (selectedMenu.Equals(activeMenu)) {
            activeMenu = null;
        } else {
            activeMenu = selectedMenu;
            selectedMenu.SetActive(true);
        }
    }
}
