﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 15f;
    private bool doMovement = true;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            doMovement = !doMovement;
        }
        if (!doMovement)
        {
            return;
        }
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        //scrolling
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y = pos.y - (scroll * 500 * scrollSpeed * Time.deltaTime);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}