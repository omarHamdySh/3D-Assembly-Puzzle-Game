using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeglectRotationX : NeglectRotation
{
    public override bool CheckRotation(Vector3 firstObjRot, Vector3 secondObjRot)
    {
        if(firstObjRot.x == secondObjRot.x || firstObjRot.x == secondObjRot.x + 180)
        {
            if (firstObjRot.y == secondObjRot.y && firstObjRot.z == secondObjRot.z)
            {
                return true;
            }
            else if (firstObjRot.y == secondObjRot.y + 180 && firstObjRot.z == secondObjRot.z + 180)
            {
                return true;
            }
        }

        return false;
    }

   
}
