using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    private Vector3 posDelta = Vector3.zero;

    private void OnMouseDown()
    {
        posDelta = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        posDelta = Input.mousePosition - posDelta;
        RotateShape(posDelta);
    }

    public void RotateShape(Vector3 posDelta)
    {
        if (Vector3.Dot(transform.up, Vector3.up) >= 0)
        {
            // Rotate Around Y Axis
            transform.Rotate(transform.up, -Vector3.Dot(posDelta, Camera.main.transform.right), Space.World);
        }
        else
        {
            // Rotate Around Y Axis but inverted
            transform.Rotate(transform.up, Vector3.Dot(posDelta, Camera.main.transform.right), Space.World);
        }

        // Rotate Around X Axis
        transform.Rotate(Camera.main.transform.right, Vector3.Dot(posDelta, Camera.main.transform.up), Space.World);
    }
}
