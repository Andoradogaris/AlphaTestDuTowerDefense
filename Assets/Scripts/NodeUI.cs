using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;
    private Node target;

    public Text sellAmount;

    public Text upgradeA1Cost;
    public Button upgradeA1Button;
    public Text upgradeA2Cost;
    public Button upgradeA2Button;
    public Text upgradeA3Cost;
    public Button upgradeA3Button;
    public Text upgradeA4Cost;
    public Button upgradeA4Button;
    public Text upgradeA5Cost;
    public Button upgradeA5Button;

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

        if (!target.isA1Upgraded)
        {
            upgradeA1Cost.text = "-" + target.turretBlueprint.upgradeA1Cost + "$";
            upgradeA1Button.interactable = true;
        }
        else if (!target.isA2Upgraded)
        {
            upgradeA2Cost.text = "-" + target.turretBlueprint.upgradeA2Cost + "$";
            upgradeA2Button.interactable = true;

            //upgradeA1Cost.text = "<i>DONE</i>";
            //upgradeButton.interactable = false;
        }
        else if (!target.isA3Upgraded)
        {
            upgradeA3Cost.text = "-" + target.turretBlueprint.upgradeA3Cost + "$";
            upgradeA3Button.interactable = true;
        }
        else if (!target.isA4Upgraded)
        {
            upgradeA4Cost.text = "-" + target.turretBlueprint.upgradeA4Cost + "$";
            upgradeA4Button.interactable = true;
        }
        else if (!target.isA5Upgraded)
        {
            upgradeA5Cost.text = "-" + target.turretBlueprint.upgradeA5Cost + "$";
            upgradeA5Button.interactable = true;
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

    public void UpgradeA2()
    {
        target.UpgradeA2Turret();
        BuildManager.instance.DeselectNode();
    }

    public void UpgradeA3()
    {
        target.UpgradeA3Turret();
        BuildManager.instance.DeselectNode();
    }

    public void UpgradeA4()
    {
        target.UpgradeA4Turret();
        BuildManager.instance.DeselectNode();
    }

    public void UpgradeA5()
    {
        target.UpgradeA5Turret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}