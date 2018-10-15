using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerBlueprint
{
    public GameObject towerPrefab;
    public int cost;

    public GameObject upgradePrefab;
    public int upgradeCost;

    public int GetSellAmmount()
    {
        return cost / 2;
    }
}
