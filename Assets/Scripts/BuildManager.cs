﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singleton
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BUILDMANAGER in scene");
            return;
        }

        instance = this;
    }
    #endregion

    private TowerBlueprint towerToBuild;
    private Platform selectedPlatform;

    public PlatformUI platformUI;

    public bool CanBuild { get { return towerToBuild != null; } }

    public void SelectPlatform(Platform platform)
    {
        if(selectedPlatform == platform)
        {
            DeselectPlatform();
            return;
        }
        selectedPlatform = platform;
        towerToBuild = null;

        platformUI.SetTarget(platform);

    }

    public void DeselectPlatform()
    {
        selectedPlatform = null;
        platformUI.Hide();
    }

    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
        selectedPlatform = null;

        platformUI.Hide();
    }

    public TowerBlueprint GetTowerToBuild()
    {
        return towerToBuild;
    }
}
