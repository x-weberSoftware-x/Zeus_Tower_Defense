using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(!buildManager.CanBuild)
        {
            return;
        }

        if (currentTower != null)
        {
            Debug.Log("Cant Build Here - TODO display on screen");
            return;
        }

        buildManager.BuildTowerOn(this);
    }

    private void OnMouseEnter()
    {
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
