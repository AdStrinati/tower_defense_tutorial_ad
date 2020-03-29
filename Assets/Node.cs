using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColorOk;
    public Color hoverColorKo;
    private Renderer rend;
    private Color startColor;
    private GameObject turret;
    public Vector3 turretPositionOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        if(turret != null)
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

        GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + turretPositionOffset, transform.rotation);
    }
}
