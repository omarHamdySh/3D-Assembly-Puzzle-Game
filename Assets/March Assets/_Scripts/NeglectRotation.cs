using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INeglectRotation
{
    bool CheckRotation(Vector3 firstObjRot, Vector3 secondObjRot);
}
public class NeglectRotation : MonoBehaviour, INeglectRotation
{
    public virtual bool CheckRotation(Vector3 firstObjRot, Vector3 secondObjRot)
    {
        return true;
    }
}
