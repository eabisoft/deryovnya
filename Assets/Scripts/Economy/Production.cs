using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Production : MonoBehaviour
{
    [SerializeField]
    private ResourcesDictionary input;
    [SerializeField]
    private ResourcesDictionary output;
    public int requiredTicks;

    // TODO можем возвращать флаг об успешности производства, если нужен
    public void Produce() {
        if (ResourcesManager.Decrease(input.Clone())) {
            ResourcesManager.Increase(output.Clone());
        }
    }

}
