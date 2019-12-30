using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveByDrag : MonoBehaviour
{
    private Camera cam;
    private Rigidbody myRb;

    private float dragSpeed = 1;
    private bool dragged;


    private float distance;

    private void Start()
    {
        cam = Camera.main;
        myRb = GetComponent<Rigidbody>();
    }
    private void OnMouseDrag()
    {
        dragged = true;
        transform.position = Vector3.Lerp(transform.position, getMousePos(), Time.deltaTime * dragSpeed);
    }

    private void OnMouseUp()
    {
        dragged = false;
    }

    public Vector2 getMousePos()
    {
        distance = Mathf.Abs(cam.transform.position.z - transform.position.z);
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        return cam.ScreenToWorldPoint(pos);
    }
}