using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;
    private Node target;

    public Text sellAmount;

    public Text upgradeA1Cost;
    public Button upgradeA1Button;

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

        if (!target.isA1Upgraded)
        {
            upgradeA1Cost.text = "-" + target.turretBlueprint.upgradeA1Cost + "$";
            upgradeA1Button.interactable = true;
        }
        else
        {
            upgradeA1Cost.text = "<i>DONE</i>";
            upgradeA1Button.interactable = false;
        }

        sellAmount.text = "+" + target.turretBlueprint.GetSellAmount() + "$";

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void UpgradeA1()
    {
        target.UpgradeA1Turret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}