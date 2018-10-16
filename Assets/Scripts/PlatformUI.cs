using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformUI : MonoBehaviour
{
    public GameObject ui;
    public Text upgradeCost;
    public Text sellAmmount;
    public Button upgradeButton;

    private Platform target;

    public void SetTarget(Platform _target)
    {
        target = _target;

        transform.position = target.transform.position;

       
        sellAmmount.text = "$" + target.towerBlueprint.GetSellAmmount(target.isUpgraded);

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.towerBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }


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

    public void Sell()
    {
        target.SellTower();
        BuildManager.instance.DeselectPlatform();
    }
}
   

