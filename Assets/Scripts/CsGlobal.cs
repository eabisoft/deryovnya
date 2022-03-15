using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class CsGlobal : ScriptableSingleton<CsGlobal>
{
    
    public static float money = 60;
    public static float buildCost = 10;

    static public bool moneyChecker () {
        if (money - buildCost < 0){
            Debug.Log("Пошел нахуй пидор, копи бабки");
            return false;
        }
        else{
            money -= buildCost;
            Debug.Log("Ну молодец ебана, построил, доволен?");
            return true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
