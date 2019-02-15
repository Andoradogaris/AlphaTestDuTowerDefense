using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapNode : MonoBehaviour
{

    public Color hoverColorTrap;
    public Color notEnoughMoneyColorTrap;
    public Vector3 positionOffsetTrap;

    [HideInInspector]
    public GameObject prefabBomb;
    public GameObject prefabPoison;
    public GameObject prefabMolotov;
    public GameObject prefabTsar;
    [HideInInspector]
    public TrapBlueprint trapBlueprint;

    private Color startColorNode;
    private Renderer rendTrap;

    private BuildManager buildManagerTrap;

    private void Start()
    {
        rendTrap = GetComponent<Renderer>();
        startColorNode = rendTrap.material.color;

        buildManagerTrap = BuildManager.instance;
    }

    public Vector3 GetBuildTrapPosition()
    {
        return transform.position + positionOffsetTrap;
    }

    private void BuildBombTrap(TrapBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.TrapCost)
        {
            Debug.Log("Pas assez d'argent pour cela");
            return;
        }

        PlayerStats.money -= blueprint.TrapCost;

        trapBlueprint = blueprint;

        GameObject _prefabBomb = (GameObject)Instantiate(blueprint.prefabTrap, GetBuildTrapPosition(), Quaternion.identity);
        prefabBomb = _prefabBomb;

        GameObject effect = (GameObject)Instantiate(buildManagerTrap.buildEffect, GetBuildTrapPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        Debug.Log("La piège a été posé.");
    }

    private void OnMouseDown()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (prefabBomb != null)
        {
            buildManagerTrap.SelectTrapNode(this);
            return;
        }

        if (!buildManagerTrap.canBuildTrap)
        {
            return;
        }

        BuildBombTrap(buildManagerTrap.GetTrapToBuild());
    }

    private void OnMouseEnter()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManagerTrap.canBuildTrap)
        {
            return;
        }

        if (buildManagerTrap.hasMoney)
        {
            rendTrap.material.color = hoverColorTrap;
        }
        else
        {
            rendTrap.material.color = notEnoughMoneyColorTrap;
        }

    }

    private void OnMouseExit()
    {
        rendTrap.material.color = startColorNode;
    }
}

