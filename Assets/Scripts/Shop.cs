using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncherTurret;
    public TurretBlueprint laserBeamerTurret;

    public TrapBlueprint prefabPoison;
    public TrapBlueprint prefabMolotov;
    public TrapBlueprint prefabTsar;

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Tourelle standard selectionnée");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Lance missile selectionné");
        buildManager.SelectTurretToBuild(missileLauncherTurret);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser beamer selectionné");
        buildManager.SelectTurretToBuild(laserBeamerTurret);
    }

    public void SelectPoisonPrefabTrap()
    {
        Debug.Log("Piège poison selectionné");
        buildManager.SelectTrapToBuild(prefabPoison);
    }

    public void SelectMolotovPrefabTrap()
    {
        Debug.Log("Coktaïl Molotov selectionné");
        buildManager.SelectTrapToBuild(prefabMolotov);
    }

    public void SelectTsarPrefabTrap()
    {
        Debug.Log("Bombe Tsar selectionnée");
        buildManager.SelectTrapToBuild(prefabTsar);
    }
}