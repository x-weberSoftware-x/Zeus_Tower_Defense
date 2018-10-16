using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerBlueprint
{
    public GameObject towerPrefab = null;
    public int cost = 100;

    public GameObject upgradePrefab = null;
    public int upgradeCost = 60;

    public int GetSellAmmount(bool upgraded)
    {
        if(upgraded == true)
        {
            return (cost + upgradeCost) / 2;
        }
        else
        {
            return cost / 2;
        }       
    }
}
