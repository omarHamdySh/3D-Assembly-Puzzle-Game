using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICompareDirection
{
    bool CheckDirection(Transform firstTransform, Transform secondTranform);
}
public class CompareDirection : MonoBehaviour, ICompareDirection
{
    //all object direction must be equal
    public virtual bool CheckDirection(Transform firstTransform, Transform secondTranform)
    {
        if (OrginalRotation(firstTransform, secondTranform))
        {
            return true;
        }
        else if (IgnoreRotX(firstTransform, secondTranform))
        {
            return true;
        }
        else if (IgnoreRotY(firstTransform, secondTranform))
        {
            return true;
        }
        else if (IgnoreRotZ(firstTransform, secondTranform))
        {
            return true;
        }
        return false;
    }


    private bool OrginalRotation(Transform firstTransform, Transform secondTranform)
    {
        if (firstTransform.forward == secondTranform.forward)
        {
            if (firstTransform.right == secondTranform.right && firstTransform.up == secondTranform.up)
            {
                return true;
            }
        }

        return false;
    }
    private bool IgnoreRotX(Transform firstTransform, Transform secondTranform)
    {
        if (firstTransform.right == secondTranform.right)
        {
            if (firstTransform.up == -secondTranform.up && firstTransform.forward == -secondTranform.forward)
            {
                return true;
            }
        }
        return false;
    }
    private bool IgnoreRotY(Transform firstTransform, Transform secondTranform)
    {
        if (firstTransform.up == secondTranform.up)
        {
            if (firstTransform.right == -secondTranform.right && firstTransform.forward == -secondTranform.forward)
            {
                return true;
            }
        }

        return false;
    }

    private bool IgnoreRotZ(Transform firstTransform, Transform secondTranform)
    {
        if (firstTransform.forward == secondTranform.forward)
        {
            if (firstTransform.right == -secondTranform.right && firstTransform.up == -secondTranform.up)
            {
                return true;
            }
        }

        return false;
    }
}
