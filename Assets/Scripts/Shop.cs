using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SetTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SetTurretToBuild(missileLauncher);
    }
}
