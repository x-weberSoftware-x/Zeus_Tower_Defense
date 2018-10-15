using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Platform : MonoBehaviour 
{
    BuildManager buildManager;

    [HideInInspector]
    public GameObject currentTower;

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

        buildManager.BuildTowerOn(this);
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
