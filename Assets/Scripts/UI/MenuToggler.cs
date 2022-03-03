using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToggler : MonoBehaviour
{
    public GameObject managedMenu;

    public void Toggle() {
        if (managedMenu != null) {
            MenuManager.ChangeActiveMenu(managedMenu);
        }
    }

    
}
