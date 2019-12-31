using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void name(float timeUnitValue);

public class SnapZone3D_Omar : MonoBehaviour
{
    [HideInInspector]
    public bool isSnapped;
    private bool isSnapping, isUnSnapping, isValidToSnap;
    [SerializeField] private float snapSpeed;
    [SerializeField] private int snapPercentageValeo = 5;

    public Vector3 snapDirectionFrom;

    private MeshRenderer meshRenderer;
    private Collider myCollider;

    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        myCollider = GetComponent<Collider>();
    }


    private void OnTriggerStay(Collider collision)
    {
        if (!isSnapping)
        {
            tryToSnap(collision);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        OnSnapHover(other.gameObject);
        if(isValidToSnap)
        evaluateSnapDirection(other.gameObject.transform.position-this.transform.position);
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

    private bool checkOrientation(GameObject snappingGameObject)
    {

        if (this.gameObject.transform.rotation == snappingGameObject.transform.rotation)
            return true;
        else
            return false;
    }

    IEnumerator snapSmoothly(GameObject snappedObject)
    {

        while (snappedObject.transform.position != this.transform.position)
        {
            yield return new WaitForSeconds(snapSpeed);
            snappedObject.transform.position =
                 snappedObject.transform.position = Vector3.Lerp(
                     snappedObject.transform.position,
                     this.transform.position,
                     snapPercentageValeo * 0.1f
                );

            //snappedObject.transform.Translate(snappedObject.transform.position, snapPercentageValeo);
        }
        yield return null;
    }

    private void evaluateSnapDirection(Vector3 differenceInDirection)
    {

        if (Mathf.Abs(differenceInDirection.x)
            > Mathf.Abs(differenceInDirection.y) &&
            Mathf.Abs(differenceInDirection.x) >
            Mathf.Abs(differenceInDirection.z))
        {
            if (differenceInDirection.x>0)
            {
                snapDirectionFrom = Vector3.right;

            }
            else if (differenceInDirection.x<0)
            {
                snapDirectionFrom = -Vector3.right;
            }
        }
        else if (Mathf.Abs(differenceInDirection.y) >
            Mathf.Abs(differenceInDirection.x) &&
            Mathf.Abs(differenceInDirection.y) >
            Mathf.Abs(differenceInDirection.z))

        {
            if (differenceInDirection.y > 0)
            {
                snapDirectionFrom = Vector3.up;

            }
            else if (differenceInDirection.y < 0)
            {
                snapDirectionFrom = -Vector3.up;
            }

        }
        else if (Mathf.Abs(differenceInDirection.z) > 
            Mathf.Abs(differenceInDirection.y)
            && Mathf.Abs(differenceInDirection.z) > 
            Mathf.Abs(differenceInDirection.x))
        {
            if (differenceInDirection.z > 0)
            {
                snapDirectionFrom = Vector3.forward;

            }
            else if (differenceInDirection.z < 0)
            {
                snapDirectionFrom = -Vector3.forward;
            }
        }
        else if (Mathf.Abs(differenceInDirection.x)
            == Mathf.Abs(differenceInDirection.z) &&
            Mathf.Abs(differenceInDirection.x) ==
            Mathf.Abs(differenceInDirection.y))
        {
            snapDirectionFrom = Vector3.zero;
        }
    }

    //Snap the game object into your valid location and do the effects of it.s
    private void snap(GameObject snappedObject)
    {
        OnSnapping(snappedObject);
        StartCoroutine(snapSmoothly(snappedObject));
        OnSnapped(snappedObject);
    }

    //Push the game object out side the snap zone.
    private void unSnap(GameObject unSnappedObject)
    {
        OnUnSnapping(unSnappedObject);
        unSnappedObject.transform.position += snapDirectionFrom *2; 
        OnUnSnapped(unSnappedObject);
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

        isSnapping = false;

        isSnapped = true;

        //Disable the mesh renderer of the snapZone.
        meshRenderer.enabled = false;
        //Disable the Collider
        myCollider.enabled = false;
        //Disable snapped game object collider in order to be un movable.
        snappedObject.GetComponent<Collider>().enabled = false;

    }

    private void OnUnSnapped(GameObject unSnappedObject)
    {
        isSnapped = false;
    }

    private void OnSnapping(GameObject snappedObject)
    {
        isSnapping = true;
    }

    private void OnUnSnapping(GameObject snappedObject)
    {
        isUnSnapping = true;
    }


}

