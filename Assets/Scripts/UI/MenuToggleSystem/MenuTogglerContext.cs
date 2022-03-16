using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Прикрепляется к объекту-контейнеру для кнопок с Menu Toggler 
// Cодержит текущее меню 
public class MenuTogglerContext : MonoBehaviour
{
    private GameObject currentMenu = null;

    public void changeActiveMenu(GameObject newMenu) {
        if (currentMenu != null)
            currentMenu.SetActive(false);

        if (newMenu.Equals(currentMenu)) {
            currentMenu = null;
        } else {
            currentMenu = newMenu;
            currentMenu.SetActive(true);
        }
    }
}
