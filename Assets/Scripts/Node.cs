using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isA1Upgraded = false;
    public bool isA2Upgraded = false;
    public bool isA3Upgraded = false;
    public bool isA4Upgraded = false;
    public bool isA5Upgraded = false;

    private Color startColor;
    private Renderer rend;

    private BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void BuildTurret(TurretBlueprint blueprint)
    {

        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("Pas assez d'argent pour cela");
            return;
        }

        PlayerStats.money -= blueprint.cost;

        turretBlueprint = blueprint;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        Debug.Log("La tourelle a été construite.");
    }

    public void SellTurret()
    {
        PlayerStats.money += turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        Destroy(turret);
        turretBlueprint = null;
        isA1Upgraded = false;
        isA2Upgraded = false;
        isA3Upgraded = false;
        isA4Upgraded = false;
        isA5Upgraded = false;
    }

    public void UpgradeA1Turret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeA1Cost)
        {
            Debug.Log("Pas assez d'argent pour améliorer la tourelle.");
            return;
        }

        PlayerStats.money -= turretBlueprint.upgradeA1Cost;

        // Supression de l'ancienne tourelle
        Destroy(turret);

        // Création de la nouvelle tourelle améliorée.
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedA1Prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        isA1Upgraded = true;

        Debug.Log("Tourelle améliorée.");
    }

    public void UpgradeA2Turret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeA2Cost)
        {
            Debug.Log("Pas assez d'argent pour améliorer la tourelle.");
            return;
        }

        PlayerStats.money -= turretBlueprint.upgradeA2Cost;

        // Supression de l'ancienne tourelle
        Destroy(turret);

        // Création de la nouvelle tourelle améliorée.
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedA2Prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        isA2Upgraded = true;

        Debug.Log("Tourelle améliorée.");
    }

    public void UpgradeA3Turret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeA3Cost)
        {
            Debug.Log("Pas assez d'argent pour améliorer la tourelle.");
            return;
        }

        PlayerStats.money -= turretBlueprint.upgradeA3Cost;

        // Supression de l'ancienne tourelle
        Destroy(turret);

        // Création de la nouvelle tourelle améliorée.
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedA3Prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        isA3Upgraded = true;

        Debug.Log("Tourelle améliorée.");
    }

    public void UpgradeA4Turret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeA4Cost)
        {
            Debug.Log("Pas assez d'argent pour améliorer la tourelle.");
            return;
        }

        PlayerStats.money -= turretBlueprint.upgradeA4Cost;

        // Supression de l'ancienne tourelle
        Destroy(turret);

        // Création de la nouvelle tourelle améliorée.
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedA4Prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        isA4Upgraded = true;

        Debug.Log("Tourelle améliorée.");
    }

    public void UpgradeA5Turret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeA5Cost)
        {
            Debug.Log("Pas assez d'argent pour améliorer la tourelle.");
            return;
        }

        PlayerStats.money -= turretBlueprint.upgradeA5Cost;

        // Supression de l'ancienne tourelle
        Destroy(turret);

        // Création de la nouvelle tourelle améliorée.
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedA5Prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        isA5Upgraded = true;

        Debug.Log("Tourelle améliorée.");
    }

    #region
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.canBuildTower)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.canBuildTower)
        {
            return;
        }

        if (buildManager.hasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    #endregion
}