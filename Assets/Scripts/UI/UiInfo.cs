using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiInfo : MonoBehaviour
{
    [SerializeField] private Text myText;

    void Update()
    {
        myText.text = "Money: " + CsGlobal.money.ToString("0.00");
    }
}
