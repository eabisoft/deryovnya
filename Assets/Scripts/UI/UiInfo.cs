using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiInfo : MonoBehaviour
{
    [SerializeField] private Text myText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = "Бабки: " + ((float)(int)(CsGlobal.money * 100)) / 100;;
    }
}
