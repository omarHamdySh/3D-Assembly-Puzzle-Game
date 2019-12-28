using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveByDrag : MonoBehaviour
{
    public Camera cam;
    public bool dragged;

    private float distance;

    private void OnMouseDrag()
    {
        dragged = true;
        transform.position = getMousePos();
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