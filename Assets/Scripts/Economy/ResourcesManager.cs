using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : ScriptableObject
{
    // TODO add all new resource types to this dictionary
    private static Dictionary<Resource, int> resources = new Dictionary<Resource, int> {
        {Resource.Food, 10},
        {Resource.Stone, 0},
        {Resource.Tree, 10}
    };

    public static Dictionary<Resource, int> Resources {
        get {return resources; }
    }

    public static bool Decrease(Resource type, int amount) {
        if (resources[type] < amount)
            return false;
        
        resources[type] -= amount;
        return true;
    }

    public static bool Decrease(Dictionary<Resource, int> input) {
        foreach(var item in input) {
            if (!hasAmountOfResource(item.Key, item.Value))
                return false;
        }

        // Мы можем вычитать лишь после проверки всех предметов в "запросе"
        foreach(var item in input) {
            Decrease(item.Key, item.Value);
        }

        return true;
    }

    public static void Increase(Resource type, int amount) {
        resources[type] += amount;
    }

    public static void Increase(Dictionary<Resource, int> input) {
        foreach(var item in input) {
            Increase(item.Key, item.Value);
        }
    }

    public static bool hasAmountOfResource(Resource type, int amount) {
        return resources[type] >= amount;
    }
}
