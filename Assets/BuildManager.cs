using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject turretToBuild;
    public static BuildManager instance;
    public GameObject standardTurretPrefab;
    
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }
}
