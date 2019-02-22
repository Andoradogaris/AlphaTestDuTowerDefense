﻿using UnityEngine;
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
    public bool isUpgraded;
    public bool V = false;
    public bool W = true;
    public bool isUpgradedA1;
    public bool V1 = false;
    public bool W1 = true;

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

    public void UpgradeTurret()
    {
        
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Pas assez d'argent pour améliorer la tourelle.");
            return;
        }

        if(isUpgraded = V)
        {
        PlayerStats.money -= turretBlueprint.upgradeCost;

        // Supression de l'ancienne tourelle
        Destroy(turret);

        // Création de la nouvelle tourelle améliorée.
        GameObject A1turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = A1turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        isUpgraded = W;

        Debug.Log("Tourelle améliorée.");
        }

        if (isUpgraded = W)
        {
            if(isUpgradedA1 = V1)
            {
                PlayerStats.money -= turretBlueprint.upgradeCostA1;

                Destroy(turret);

                GameObject A2turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefabA1, GetBuildPosition(), Quaternion.identity);
                turret = A2turret;

                GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
                Destroy(effect, 1f);

                isUpgradedA1 = W1;
            }
        }
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
        isUpgraded = false;
    }

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

        if (!buildManager.canBuild)
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

        if (!buildManager.canBuild)
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

}