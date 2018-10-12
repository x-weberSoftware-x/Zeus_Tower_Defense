using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour 
{
    public TowerBlueprint lightningTower;
    public TowerBlueprint fireTower;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectLightningTower()
    {
        buildManager.SelectTowerToBuild(lightningTower);
    }

    public void SelectFireTower()
    {
        buildManager.SelectTowerToBuild(fireTower);
    }
}
