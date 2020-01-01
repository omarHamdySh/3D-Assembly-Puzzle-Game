using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drage3DObjects : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    [HideInInspector] public bool isDragged;
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(transform.position).z;

        mOffset = transform.position - GetMousePos();
    }

    private void OnMouseDrag()
    {
        if (SnapZone3D_Omar.snapOnMouseUp)
        {
            isDragged = true;
        }

        transform.position = GetMousePos() + mOffset;
    }

    private void OnMouseUp()
    {
        // Check the object if it on the right postion or not if make the snapzone code
        isDragged = false;
    }

    private Vector3 GetMousePos()
    {
        // Pixel Coordinates (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // Z Coordinate of game object on screen
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
