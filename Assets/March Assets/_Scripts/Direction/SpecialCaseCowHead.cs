using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCaseCowHead : CompareDirection
{
    public override bool CheckDirection(Transform firstTransform, Transform secondTranform)
    {
        if (firstTransform.forward == secondTranform.forward)
        {
            if (firstTransform.right == secondTranform.right && firstTransform.up == secondTranform.up)
            {
                return true;
            }
        }
        else if(firstTransform.up == -transform.forward)
        {
            return true;
        }

        return false;
    }
}
