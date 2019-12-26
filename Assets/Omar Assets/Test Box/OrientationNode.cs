using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationNode : MonoBehaviour
{
    private void Update()
    {
        if (!SelectionScript.instance.SelectedObject)
        {
            return;
        }

        if (this.gameObject == SelectionScript.instance.SelectedObject)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.Rotate(transform.up, 90, Space.Self);

            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                transform.Rotate(transform.up, -90, Space.Self);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                transform.Rotate(transform.right, 90, Space.Self);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                transform.Rotate(transform.right, -90, Space.Self);
            }

            //if (Input.GetAxis("HorizontalRotate") != 0 || Input.GetAxis("VerticalRotate") != 0)
            //{
            //    RotateShape((new Vector3(Input.GetAxis("HorizontalRotate"), Input.GetAxis("VerticalRotate"), 0)) * rotateSpeed);
            //}
        }
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
