using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void SnappingEvent(SnapZone3D_Omar snapZone);

public class SnapZone3D_Omar : MonoBehaviour
{
    [HideInInspector]
    public bool isSnapped;
    private bool isSnapping, isUnSnapping, isValidToSnap;
    [SerializeField] private float snapSpeed;
    [SerializeField] private int snapPercentageValue = 5;

    public static bool snapOnMouseUp = true;

    public Vector3 snapDirectionFrom;

    private MeshRenderer meshRenderer;
    private Collider myCollider;

    public SnappingEvent OnSnappedEvent, OnUnSnappedEvent;

    [Header("Snap Events")]
    public UnityEvent OnSnapEnter, OnSnapExit, OnSnapping, OnUnSnapping, OnSnapped, OnUnSnapped;
    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        myCollider = GetComponent<Collider>();
    }


    private void OnTriggerStay(Collider collision)
    {
        if (!isSnapping && !collision.gameObject.GetComponent<Drage3DObjects>().isDragged)
        {
            tryToSnap(collision);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == other.gameObject.tag)
        {
            fireOnSnapEnterEvent(other.gameObject);
            if (isValidToSnap)
                evaluateSnapDirection(other.gameObject.transform.position - this.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == other.gameObject.tag)
        {
            fireOnSnapExitEvent(other.gameObject);
        }
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
                     snapPercentageValue * 0.1f
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
            if (differenceInDirection.x > 0)
            {
                snapDirectionFrom = Vector3.right;

            }
            else if (differenceInDirection.x < 0)
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
        fireOnSnappingEvent(snappedObject);
        StartCoroutine(snapSmoothly(snappedObject));
        fireOnSnappedEvent(snappedObject);
    }

    //Push the game object out side the snap zone.
    private void unSnap(GameObject unSnappedObject)
    {
        fireOnUnSnappingEvent(unSnappedObject);
        unSnappedObject.transform.position += snapDirectionFrom * 2;
        fireUnSnappedEvent(unSnappedObject);
    }

    private void fireOnSnapEnterEvent(GameObject snappedObject)
    {
        OnSnapEnter.Invoke();
        //Play Hovering Animation

        //Check wheather it is in the valid orientation to be snapped or not.
        this.isValidToSnap = checkOrientation(snappedObject.gameObject);
    }

    private void fireOnSnapExitEvent(GameObject unSnappedObject)
    {
        OnSnapExit.Invoke();
    }

    private void fireOnSnappedEvent(GameObject snappedObject)
    {

        isSnapping = false;

        isSnapped = true;

        //Disable the mesh renderer of the snapZone.
        meshRenderer.enabled = false;
        //Disable the Collider
        myCollider.enabled = false;
        //Disable snapped game object collider in order to be un movable.
        snappedObject.GetComponent<Collider>().enabled = false;

        OnSnapped.Invoke();

        if (OnSnappedEvent != null)
            OnSnappedEvent(this);
    }

    private void fireUnSnappedEvent(GameObject unSnappedObject)
    {
        isSnapped = false;
        OnUnSnapped.Invoke();
        if (OnUnSnappedEvent != null)
            OnUnSnappedEvent(this);
    }

    private void fireOnSnappingEvent(GameObject snappedObject)
    {
        isSnapping = true;
        OnSnapping.Invoke();
    }

    private void fireOnUnSnappingEvent(GameObject snappedObject)
    {
        isUnSnapping = true;
        OnUnSnapping.Invoke();
    }


}

