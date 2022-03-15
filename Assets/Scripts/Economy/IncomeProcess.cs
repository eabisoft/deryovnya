using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeProcess : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CsGlobal.money += 0.001f;
    }
}
