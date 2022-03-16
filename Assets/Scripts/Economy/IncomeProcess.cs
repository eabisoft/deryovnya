using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeProcess : MonoBehaviour
{
    private int ticks;
    private Production production;

    void Start() {
        production = GetComponent<Production>();
    }

    void FixedUpdate()
    {
        ticks++;
        if (ticks == production.requiredTicks) {
            production.Produce();
            ticks = 0;
        }
    }
}
