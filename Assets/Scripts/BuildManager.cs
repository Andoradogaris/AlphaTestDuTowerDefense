using UnityEngine;

public class BuildManager : MonoBehaviour
{

    #region Singleton
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Il y a déjà un BuildManager dans la scène !");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TrapBlueprint trapToBuild;
    private TrapNode selectedTrapNode;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool canBuildTower { get { return turretToBuild != null; } }
    public bool canBuildTrap { get { return trapToBuild != null; } }
    public bool hasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }



    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public void SelectTrapToBuild(TrapBlueprint trapBomb)
    {
        trapToBuild = trapBomb;
        DeselectTrapNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public TrapBlueprint GetTrapToBuild()
    {
        return trapToBuild;
    }

    public void SelectNode(Node node)
    {

        if (node == selectedNode)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void SelectTrapNode(TrapNode trapNode)
    {

        if (trapNode == selectedTrapNode)
        {
            DeselectTrapNode();
            return;
        }

        selectedTrapNode = trapNode;
        trapToBuild = null;
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void DeselectTrapNode()
    {
        selectedTrapNode = null;
    }

}