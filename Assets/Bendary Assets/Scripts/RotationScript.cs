using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 0;

    [HideInInspector] public bool IsSelected = false;

    private void Update()
    {
        if (IsSelected)
        {
            if (Input.GetAxis("HorizontalRotate") != 0 || Input.GetAxis("VerticalRotate") != 0)
            {
                RotateShape((new Vector3(Input.GetAxis("HorizontalRotate"), Input.GetAxis("VerticalRotate"), 0)) * rotateSpeed);
            }
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


    private void OnMouseDown()
    {
        if (SelectionScript.instance.SelectedObject)
        {
            SelectionScript.instance.SelectedObject.GetComponent<RotationScript>().IsSelected = false;
            SelectionScript.instance.SelectedObject.GetComponent<RotationScript>().DisableSelectionOutline();
        }

        SelectionScript.instance.SelectedObject = gameObject;

        IsSelected = true;
        ShowSelectionOutline();
    }

    public void ShowSelectionOutline()
    {

    }

    public void DisableSelectionOutline()
    {

    }
}
