using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUI : MonoBehaviour
{
    public GameObject ui;

    private Platform target;

    public void SetTarget(Platform _target)
    {
        target = _target;

        transform.position = target.transform.position;

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTower();
        BuildManager.instance.DeselectPlatform();
    }
}
   

