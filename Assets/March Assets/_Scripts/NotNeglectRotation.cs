using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotNeglectRotation : MonoBehaviour, INeglectRotation
{
    public bool CheckRotation(Vector3 firstObjRot, Vector3 secondObjRot)
    {
        if (firstObjRot == secondObjRot)
        {
            return true;
        }
        else if(firstObjRot.x == secondObjRot.x + 180 && firstObjRot.y == secondObjRot.y + 180 && firstObjRot.z == secondObjRot.z + 180)
        {
            return true;
        }
        return false;
    }
}
