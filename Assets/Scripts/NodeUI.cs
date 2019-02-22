using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;
    private Node target;

    public Text sellAmount;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text upgradeCostA1;
    public Button upgradeButtonA1;

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "-" + target.turretBlueprint.upgradeCost + "$";
            upgradeButton.interactable = true;
            upgradeButtonA1.interactable = false;
        }
        if (!target.isUpgradedA1)
        {
            upgradeCostA1.text = "-" + target.turretBlueprint.upgradeCostA1 + "$";
            upgradeButton.interactable = false;
            upgradeButtonA1.interactable = true;
        }
        else
        {
            upgradeCost.text = "<i>DONE</i>";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "+" + target.turretBlueprint.GetSellAmount() + "$";

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}