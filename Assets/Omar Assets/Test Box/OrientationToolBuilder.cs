using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationToolBuilder : MonoBehaviour
{
    public enum ToolType
    {
        rightOrientationTool,
        leftOrientationTool,
        topOrientationTool,
        BottomOrientationTool,
        forwardOrientationTool,
        BackwardOrientationTool
    }
    public enum OrientationMode
    {
        Rotational,
        Positional
    }

    GameObject
        orientRight,
        orientLeft,
        orientUp,
        orientBottom,
        orientForward,
        orientBackward;

    private bool testing;
    public GameObject prefab;
    OrientationMode currentOrientationMode;

    [ExecuteInEditMode]
    private void Start()
    {
        currentOrientationMode = OrientationMode.Positional;

        InstantiateOrientationObjects();
    }

    /// <summary>
    /// Instantiate Objects in 6 directions in order to use for orientation (Positioning and Rotation)
    /// </summary>
    private void InstantiateOrientationObjects()
    {
        //Instantiate the follower contatiner.
        //Add the follower scritp to it in order to make it follows the selected object.
        //Change the instantiated objects parent to be the follower container instead of the selected object.
        

        if (!orientRight)
            orientRight = Instantiate(prefab, transform.forward, Quaternion.identity, this.transform);
            orientRight.AddComponent<ToolItem>().thisToolType = ToolType.rightOrientationTool; ;

        if (!orientLeft)
            orientLeft = Instantiate(prefab, -transform.forward, Quaternion.identity, this.transform);
            orientLeft.AddComponent<ToolItem>().thisToolType = ToolType.leftOrientationTool;

        if (!orientUp)
            orientUp = Instantiate(prefab, transform.up, Quaternion.identity, this.transform);
            orientUp.AddComponent<ToolItem>().thisToolType = ToolType.topOrientationTool;

        if (!orientBottom)
            orientBottom = Instantiate(prefab, -transform.up, Quaternion.identity, this.transform);
            orientBottom.AddComponent<ToolItem>().thisToolType = ToolType.BottomOrientationTool;

        if (!orientForward)
            orientForward = Instantiate(prefab, transform.right, Quaternion.identity, this.transform);
            orientForward.AddComponent<ToolItem>().thisToolType = ToolType.forwardOrientationTool;
            
        if (!orientBackward)
            orientBackward = Instantiate(prefab, -transform.right, Quaternion.identity, this.transform);
            orientBackward.AddComponent<ToolItem>().thisToolType = ToolType.BackwardOrientationTool;
    }

    public void orientAccordingly(ToolType toolType)
    {
        //Create the logic of the rotation and positioning in each case of the cases bellow

        switch (currentOrientationMode)
        {
            case OrientationMode.Rotational:
                switch (toolType)
                {
                    case ToolType.rightOrientationTool:
                        
                        break;
                    case ToolType.leftOrientationTool:
                        break;
                    case ToolType.topOrientationTool:
                        break;
                    case ToolType.BottomOrientationTool:
                        break;
                    case ToolType.forwardOrientationTool:
                        break;
                    case ToolType.BackwardOrientationTool:
                        break;
                    default:
                        break;
                }
                break;
            case OrientationMode.Positional:
                switch (toolType)
                {
                    case ToolType.rightOrientationTool:
                        break;
                    case ToolType.leftOrientationTool:
                        break;
                    case ToolType.topOrientationTool:
                        break;
                    case ToolType.BottomOrientationTool:
                        break;
                    case ToolType.forwardOrientationTool:
                        break;
                    case ToolType.BackwardOrientationTool:
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }

    }

    /// <summary>
    /// Create a method that will destroy the orientation objects of the previously selected object.
    /// and Re create the orientation objects for the newely selected objects.
    /// </summary>


    #region Second Approach
    //Second Approach
    public void rotateWithDelta(Vector2  swipeValue) { 
    
    }

    #endregion
}
