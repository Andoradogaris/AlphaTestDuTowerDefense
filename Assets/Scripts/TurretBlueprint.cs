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

    public GameObject upgradedA2Prefab;
    public int upgradeA2Cost;

    public GameObject upgradedA3Prefab;
    public int upgradeA3Cost;

    public GameObject upgradedA4Prefab;
    public int upgradeA4Cost;

    public GameObject upgradedA5Prefab;
    public int upgradeA5Cost;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}