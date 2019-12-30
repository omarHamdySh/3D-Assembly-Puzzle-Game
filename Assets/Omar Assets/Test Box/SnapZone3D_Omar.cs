using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void name(float timeUnitValue);

public class SnapZone3D_Omar : MonoBehaviour
{
    public bool isSnapped,  isUnSnapped;
    private bool isSnapping, isUnSnapping, isValidToSnap;
    
    private void OnTriggerStay(Collider collision)
    {
        tryToSnap(collision);
    }


    private void OnTriggerEnter(Collider other)
    {
        OnSnapHover(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {

    }

    private void tryToSnap(Collider collision)
    {
        //start the snapping process if this is the object intended to be snapped.
        if (gameObject.tag == collision.gameObject.tag && this.isValidToSnap)
            snap(collision.gameObject);
        else if (gameObject.tag == collision.gameObject.tag && !this.isValidToSnap)
            unSnap(collision.gameObject);
    }

    private bool checkOrientation(GameObject snappingGameObject) {

        if (this.gameObject.transform.rotation == snappingGameObject.transform.rotation)
            return true;
        else 
            return false;
    }

    //Snap the game object into your valid location and do the effects of it.s
    private void snap(GameObject snappedObject) { 
    
    }
    
    //Push the game object out side the snap zone.
    private void unSnap(GameObject unSnappedObject) { 
    
    }

    private void OnSnapHover(GameObject snappedObject)
    {
        //Play Hovering Animation

        //Check wheather it is in the valid orientation to be snapped or not.
        if (gameObject.tag == snappedObject.gameObject.tag)
            this.isValidToSnap = checkOrientation(snappedObject.gameObject);
    }

    private void OnSnapExit(GameObject unSnappedObject)
    {

    }

    private void OnSnapped(GameObject snappedObject)
    {

    }

    private void OnUnSnapped(GameObject unSnappedObject)
    {

    }

    private void OnSnapping(GameObject snappedObject) { 
    
    }

    private void OnUnSnapping(GameObject snappedObject) { 

    }
    

}

