using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationNode : MonoBehaviour
{
    enum OrientationMode
    {
        Positional,
        Rotational
    }

    enum Axis
    {
        X,
        Y,
        Z
    }

    enum ValueEditType
    {
        Incrementatl,
        Decremental
    }

    OrientationMode orientationMode;
    
    private float step = 1;

    private void Update()
    {
        if (!SelectionScript.instance.SelectedObject)
        {
            return;
        }

        adjustSnapStep();

        toggleOrientationMode();

        OrientSelectedObject();
    }

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

    private void OrientSelectedObject()
    {
        if (this.gameObject == SelectionScript.instance.SelectedObject)
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

    public void orientSelectedObject(bool x, bool y, bool z, bool sign)
    {

        if (this.gameObject == SelectionScript.instance.SelectedObject)
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

                    transform.Rotate(
                        (x == true ? Vector3.right :
                        (y == true ? Vector3.up :
                        (z == true ? Vector3.forward : Vector3.zero))),
                        (sign == true ? 90 : -90),
                        Space.World);
                    break;
            }
        }
    }
}
