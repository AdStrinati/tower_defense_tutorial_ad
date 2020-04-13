using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurretBlueprint turretToBuild;
    public static BuildManager instance;
    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;
    
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    public bool CanBuild { get { return turretToBuild != null;  } }
   
    public bool EnoughMoney { get { return PlayerStats.money >= turretToBuild.cost;  } }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node) {

        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Stronzo figlio di puttana");
            return;
        }
        PlayerStats.money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }
}
