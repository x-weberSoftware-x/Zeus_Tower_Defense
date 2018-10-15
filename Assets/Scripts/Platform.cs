using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Platform : MonoBehaviour 
{
    BuildManager buildManager;

    [HideInInspector]
    public GameObject currentTower;
    [HideInInspector]
    public TowerBlueprint towerBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    public Color hoverColor;
    private Color startColor;

    private Renderer rend;

    

    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (currentTower != null)
        {
            buildManager.SelectPlatform(this);
            return;
        }

        if(!buildManager.CanBuild)
        {
            return;
        }

        BuildTower(buildManager.GetTowerToBuild());
    }

    void BuildTower(TowerBlueprint blueprint)
    {
        if (PlayerStats.souls < blueprint.cost)
        {
            return;
        }

        PlayerStats.souls -= blueprint.cost;

        GameObject tower = Instantiate(blueprint.towerPrefab, transform.position, transform.rotation);
        currentTower = tower;
    }

    public void UpgradeTower()
    {
        if (PlayerStats.souls < towerBlueprint.upgradeCost)
        {
            return;
        }

        PlayerStats.souls -= towerBlueprint.upgradeCost;

        //Get rid of old tower
        Destroy(currentTower);

        //build new tower
        GameObject tower = Instantiate(towerBlueprint.upgradePrefab, transform.position, transform.rotation);
        currentTower = tower;

        isUpgraded = true;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
