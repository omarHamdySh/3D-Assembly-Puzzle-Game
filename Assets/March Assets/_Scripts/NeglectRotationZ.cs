using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeglectRotationZ : NeglectRotation
{
    public override bool CheckRotation(Vector3 firstObjRot, Vector3 secondObjRot)
    {
        if (firstObjRot.z == secondObjRot.z || firstObjRot.z == secondObjRot.z + 180)
        {
            if (firstObjRot.x == secondObjRot.x && firstObjRot.y == secondObjRot.y)
            {
                return true;
            }
            else if (firstObjRot.x == secondObjRot.x + 180 && firstObjRot.y == secondObjRot.y + 180)
            {
                return true;
            }
        }

        return false;
    }
}
