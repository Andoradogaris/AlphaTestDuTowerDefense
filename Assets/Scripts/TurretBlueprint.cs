using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{

    public GameObject prefab;
    public int cost;

    public GameObject upgradedA1Prefab;
    public int upgradeA1Cost;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}