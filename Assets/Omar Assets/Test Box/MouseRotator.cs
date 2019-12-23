using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseRotator : MonoBehaviour
{
    public float rotSpeed = 20;

    [System.Obsolete]
    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
        transform.RotateAroundLocal(Camera.main.transform.up, -rotX);
        transform.RotateAroundLocal(Camera.main.transform.right, rotY);

    }


}
