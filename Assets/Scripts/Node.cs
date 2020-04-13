using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColorOk;
    public Color hoverColorKo;
    private Renderer rend;
    private Color startColor;
    public GameObject turret;
    public Vector3 turretPositionOffset;
    BuildManager buildManager;
    
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }


    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (turret != null || !buildManager.EnoughMoney)
        {
            rend.material.color = hoverColorKo;
        }
        else
        {
            rend.material.color = hoverColorOk;
        }
        
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        
        if(turret != null)
        {
            Debug.Log("diocane");
            return;
        }

        //build turret

        if(!buildManager.CanBuild)
        {
            return;
        }
        buildManager.BuildTurretOn(this);
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + turretPositionOffset;
    }
}
