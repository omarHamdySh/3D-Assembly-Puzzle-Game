using System.Collections;
using UnityEngine;

public class OrientationNode : MonoBehaviour
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
        if (!SelectionScript.instance.SelectedObject)
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
                orientSelectedObject(Vector3.right, valueEditType == ValueEditType.Incrementatl);
                break;
            case Axis.Y:
                orientSelectedObject(Vector3.up, valueEditType == ValueEditType.Incrementatl);
                break;
            case Axis.Z:
                orientSelectedObject(Vector3.forward, valueEditType == ValueEditType.Incrementatl);
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
    /// <param name="signed"></param>
    public void orientSelectedObject(Vector3 axis, bool signed)
    {

        if (this.gameObject == SelectionScript.instance.SelectedObject)
        {
            switch (orientationMode)
            {
                case OrientationMode.Positional:

                    transform.position = new Vector3(
                        (axis.x != 0 ? transform.position.x + (signed == true ? step : -step) : transform.position.x),
                        (axis.y != 0 ? transform.position.y + (signed == true ? step : -step) : transform.position.y),
                        (axis.z != 0 ? transform.position.z + (signed == true ? step : -step) : transform.position.z)
                        );
                    break;
                case OrientationMode.Rotational:
                    //transform.Rotate(axis,(sign == true ? 90 : -90),Space.World);

                    // Bendary Modification
                    if (!isRotate)
                    {
                        isRotate = true;
                        StartCoroutine(RotateSlow(axis,
                            (signed == true ? 90 : -90)));
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
