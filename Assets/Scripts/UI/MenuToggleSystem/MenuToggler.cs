using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// В родительском объекте должен содержаться компонент MenuTogglerContext
// Переключает текущее меню в родительском компоненте на выбранное 
public class MenuToggler : MonoBehaviour
{
    public GameObject managedMenu;
    private MenuTogglerContext context;

    void Start() {
        context = gameObject.GetComponentInParent<MenuTogglerContext>();

        // TODO А в юнити вообще принято ошибки кидать?
        if (context == null)
            throw new System.Exception("Context must be defined in parent component");
        if (managedMenu == null)
            throw new System.Exception("Managed menu must be specified");
    }

    public void Toggle() {
        context.changeActiveMenu(managedMenu);
    }
}
