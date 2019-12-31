﻿using System.Collections;
using UnityEngine;

public class OrientationNode_bendary : MonoBehaviour
{
    OrientationMode orientationMode;
    private float step = 1;
    private bool isRotate = false;         // Bendary Modify

    /// <summary>
    /// 
    /// </summary>
    enum OrientationMode
    {
        Positional,
        Rotational
    }

    /// <summary>
    /// 
    /// </summary>
    enum Axis
    {
        X,
        Y,
        Z
    }

    /// <summary>
    /// 
    /// </summary>
    enum ValueEditType
    {
        Incrementatl,
        Decremental
    }


    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        if (!SelectionManager.instance.selectedObject)
        {
            return;
        }

        adjustSnapStep();

        toggleOrientationMode();

        OrientSelectedObject();
    }

    /// <summary>
    /// 
    /// </summary>
    private void adjustSnapStep()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Plus))
        {
            if (orientationMode == OrientationMode.Positional)
            {
                step += 0.5f;
            }
        }
        else if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
        {
            if (orientationMode == OrientationMode.Positional)
            {
                step -= 0.5f;
            }
        }
        step = Mathf.Clamp(step, 0.5f, 1.5f);
    }

    /// <summary>
    /// 
    /// </summary>
    private void OrientSelectedObject()
    {
        if (this.gameObject == SelectionManager.instance.selectedObject)
        {
            switch (orientationMode)
            {
                case OrientationMode.Positional:
                    Move();
                    break;
                case OrientationMode.Rotational:
                    Rotate();
                    break;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void toggleOrientationMode()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            switch (orientationMode)
            {
                case OrientationMode.Positional:
                    orientationMode = OrientationMode.Rotational;
                    break;
                case OrientationMode.Rotational:
                    orientationMode = OrientationMode.Positional;
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            mapAndPerformOrientation(Axis.X, ValueEditType.Incrementatl);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            mapAndPerformOrientation(Axis.X, ValueEditType.Decremental);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            mapAndPerformOrientation(Axis.Z, ValueEditType.Incrementatl);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            mapAndPerformOrientation(Axis.Z, ValueEditType.Decremental);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            mapAndPerformOrientation(Axis.Y, ValueEditType.Incrementatl);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            mapAndPerformOrientation(Axis.Y, ValueEditType.Decremental);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            mapAndPerformOrientation(Axis.Y, ValueEditType.Decremental);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            mapAndPerformOrientation(Axis.Y, ValueEditType.Incrementatl);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            mapAndPerformOrientation(Axis.X, ValueEditType.Incrementatl);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            mapAndPerformOrientation(Axis.X, ValueEditType.Decremental);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            mapAndPerformOrientation(Axis.Z, ValueEditType.Decremental);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            mapAndPerformOrientation(Axis.Z, ValueEditType.Incrementatl);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="axis"></param>
    /// <param name="valueEditType"></param>
    private void mapAndPerformOrientation(Axis axis, ValueEditType valueEditType)
    {
        switch (axis)
        {
            case Axis.X:
                orientSelectedObject(true, false, false, valueEditType == ValueEditType.Incrementatl);
                break;
            case Axis.Y:
                orientSelectedObject(false, true, false, valueEditType == ValueEditType.Incrementatl);
                break;
            case Axis.Z:
                orientSelectedObject(false, false, true, valueEditType == ValueEditType.Incrementatl);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <param name="sign"></param>
    public void orientSelectedObject(bool x, bool y, bool z, bool sign)
    {

        if (this.gameObject == SelectionManager.instance.selectedObject)
        {
            switch (orientationMode)
            {
                case OrientationMode.Positional:

                    transform.position = new Vector3(
                        (x == true ? transform.position.x + (sign == true ? step : -step) : transform.position.x),
                        (y == true ? transform.position.y + (sign == true ? step : -step) : transform.position.y),
                        (z == true ? transform.position.z + (sign == true ? step : -step) : transform.position.z)
                        );
                    break;
                case OrientationMode.Rotational:

                    //transform.Rotate(
                    //    (x == true ? Vector3.right :
                    //    (y == true ? Vector3.up :
                    //    (z == true ? Vector3.forward : Vector3.zero))),
                    //    (sign == true ? 90 : -90),
                    //    Space.World);

                    // Bendary Modify
                    if (!isRotate)
                    {
                        isRotate = true;
                        StartCoroutine(RotateSlow((x == true ? Vector3.right :
                            (y == true ? Vector3.up :
                            (z == true ? Vector3.forward : Vector3.zero))),
                            (sign == true ? 90 : -90)));
                    }
                    break;
            }
        }
    }

    // Bendary Modify
    [SerializeField] private float rotateSpeed;
    [SerializeField] private int rotateValeo = 5;
    IEnumerator RotateSlow(Vector3 axis, int sign)
    {
        if (sign > 0)
        {
            for (int i = 0; i < sign; i += rotateValeo)
            {
                yield return new WaitForSeconds(rotateSpeed);
                transform.Rotate(axis, rotateValeo, Space.World);
            }
        }
        else if (sign < 0)
        {
            for (int i = 0; i > sign; i -= rotateValeo)
            {
                yield return new WaitForSeconds(rotateSpeed);
                transform.Rotate(axis, -rotateValeo, Space.World);
            }
        }
        isRotate = false;
        yield return null;
    }
}
