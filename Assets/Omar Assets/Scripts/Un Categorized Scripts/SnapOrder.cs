using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region SnapOrder's SnapOrderFlag  Enum

/// <summary>
/// Interactable state means that the object is not snapped and it can be interacted with.
/// Snapped state indicates that the object is snapped which means that the previous 
/// snap order object in the snap order objects list that its collider is disabled because it can't be interacted with at the moment.
/// But the recent snapped object can be interacted with only if the next snap object is flagged with interactable.
/// </summary>
public enum SnapOrderFlag
{
    INTERACTABLE,
    SNAPPED
}

#endregion
public class SnapOrder : MonoBehaviour
{
    #region SnapOrder Attributes


    protected       Collider                thisCollider;                   //The collider of the this snappable object
    protected       SnapOrder               AssemblyBase;                   //This is first snappable object in the list

    [Tooltip("The snap flag of this snappable object that indecates whether it is (SNAPPED) to its snap zone or not -> (INTERACTABLE). \nUsage: readonly \nRequired: False")]
    public          SnapOrderFlag           snapFlag;                       //The snap flag of the current object 

    [Tooltip("Here you must insert all the snappable objects in ordered their right order (Snap Order List), will be ordered according to the insertion order. \nRequired: true")]
    public          List<SnapOrder>         snapOrderObjects;               //Snap objects list that retain the order of the snapping

    [Tooltip("Here you must insert all the snap zones of the next object(s) in the snap order list \nRequired: true")]
    public          List<GameObject>        snapZones;                      //The snap zones of the objects that supposed to be snapped to this snappable object.

    [Tooltip("Here you must insert the snap zone of the \nRequired: true")]
    public          GameObject              MySnapZone;                     //The snap zone that this snappable object suppose to be snapped to.

    #endregion

    #region SnapOrder Methods (Logic)

    /// <summary>
    /// The snapFlag is to tell whether or not the object is snapped.
    /// 
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        snapFlag = SnapOrderFlag.INTERACTABLE;                              //Inialize the snap flag with interactable;
        thisCollider = GetComponent<Collider>();                            //Get this object's collider
        SwitchSnapAreasOff();                                               //Switch off all snap areas 
        AssemblyBase = snapOrderObjects[0];                                 //Get the first snappable object in the list to be tha base.
        AssemblyBase.SwitchSnapAreasOn();                                   //Switch the snappable objects' base object's snap areas on.
    }

    /// <summary>
    /// OnSnappingThis()
    /// This method will be called at the method SnapObject() in the VRTK_SnapDrobZone.cs
    /// This piece of logic is added by US at Bright vision in the VRTK script;
    /// On Snapping this snappable object a bunch of actions should happen excluding
    /// the base snappable object because it has different behavior.
    /// 
    /// Method functionality:
    ///     (1) check if it is not the base snappable object because tha base has differnet behavior.
    ///     (2) Mark the flag of the snappable object to be Snapped.
    ///     (3) Check if the previous snappable object in the list is not the base snappable object.
    ///     (4) if the previous snappable object in the list is not the base then disable its collider in order to be still.
    ///     (5) Turn off the collider of the snap zone of this snappable object in order to avoid colliders conflects.
    ///     (6) Switch the snap zone(s) of the next snappable object(s).
    ///     
    /// Future Version of this method functionality should include:
    ///     (1) There must be an associate class to declare a level of snap order  which the level criteria should be as following:
    ///         - More than on object can be in the same snap order level.
    ///         - The whole level has to be completed in order to move on tot he next snap order level.
    ///         - After completing the snap order level the colliders of all the finished level objects must be disabled.
    ///     (2) There is something important I forgut but it may be included in the previous point or not.
    /// </summary>
    public void OnSnappingThis()
    {
        //check if it is not the base snappable object
        if (this != AssemblyBase)                                                      
        {
            //Mark the flag of the snappable object to be SNAPPED
            snapFlag = SnapOrderFlag.SNAPPED;
           
            int thisSnapOrderIndex = snapOrderObjects.IndexOf(this);
           
            //Check if the previous snappable object in the list is not the base snappable object
            if (snapOrderObjects[thisSnapOrderIndex - 1] != AssemblyBase)
            {
                //if the previous snappable object in the list is not the base then disable its collider in order to be still
                snapOrderObjects[thisSnapOrderIndex - 1].thisCollider.enabled = false;
            }

            //Turn off the collider of the snap zone of this snappable object in order to avoid colliders conflects.
            this.MySnapZone.GetComponent<Collider>().enabled = false;

            //Switch on the snap zone(s) of the next snappable object(s)
            SwitchSnapAreasOn();
        }

    }

    /// <summary>
    /// This method is totally the opposite behavior of the OnSnappingThis().
    /// </summary>
    public void OnUnSnappingThis()
    {
        //check if it is not the base snappable object
        if (this != AssemblyBase)
        {
            //Mark the flag of the snappable object to be INTERACTABLE
            snapFlag = SnapOrderFlag.INTERACTABLE;

            int thisSnapOrderIndex = snapOrderObjects.IndexOf(this);

            //Check if the previous snappable object in the list is not the base snappable object
            if (snapOrderObjects[thisSnapOrderIndex - 1] != AssemblyBase)
            {
                //if the previous snappable object in the list is not the base then enable its collider in order to be still
                snapOrderObjects[thisSnapOrderIndex - 1].thisCollider.enabled = true;
            }
          
            //Turn on the collider of the snap zone of this snappable object in order to be able to snap this snappable object again.
            this.MySnapZone.GetComponent<Collider>().enabled = true;

            //Switch off the snap zone(s) of the next snappable object(s)
            SwitchSnapAreasOff();
        }
    }

    /// <summary>
    /// Method Funtionality:
    ///     - Loop on the snapZones that are childs of this snappable object.
    ///     - Turn enable each's collider on.
    /// </summary>
    protected void SwitchSnapAreasOn()
    {
        foreach (var snapAreaObj in snapZones)
        {
            snapAreaObj.GetComponent<Collider>().enabled = true;
        }
    }

    /// <summary>
    /// Method Funtionality:
    ///     - Loop on the snapZones that are childs of this snappable object.
    ///     - Turn enable each's collider off.
    /// </summary>
    protected void SwitchSnapAreasOff()
    {
        foreach (var snapAreaObj in snapZones)
        {
            snapAreaObj.GetComponent<Collider>().enabled = false;
        }
    }

    #endregion

    #region   Deprecated Logic
   
    /// <summary>
    /// We had tried this version of the snap object logic but unfortunatily it hasn't achevied the desired results
    /// The problems we faced are the following:
    ///     - The VRTK is playing in the parenting of the interactable objects.
    ///     - We can't just remove or edit the snap zones in run time.
    ///     - We can't freely controll the order of the snapping unless we listen to the snapping and unsnapping events.
    /// </summary>

    //void Update()
    //{
    //if (nextInteractableObject)
    //{
    //    if (nextInteractableObject.snapFlag == SnapOrderFlag.SNAPPED && thisCollider.enabled)
    //    {
    //        if (thisCollider != null)
    //        {
    //            thisCollider.enabled = false;
    //        }
    //    }
    //    else if ((nextInteractableObject.snapFlag == SnapOrderFlag.INTERACTABLE && !thisCollider.enabled))
    //    {
    //        if (thisCollider != null)
    //        {
    //            thisCollider.enabled = true;
    //        }
    //    }
    //}
    //if (this.snapFlag == SnapOrderFlag.SNAPPED)
    //{
    //    SwitchSnapAreasOn();
    //}
    //else if (this.snapFlag == SnapOrderFlag.INTERACTABLE)
    //{
    //    SwitchSnapAreasOff();
    //}
    //   
    //if (snapFlag == SnapOrderFlag.SNAPPED)
    //{
    //    int thisSnapOrderIndex = snapOrderObjects.IndexOf(this);

    //    //if (MySnapZone)
    //    //{
    //    //    this.transform.position = MySnapZone.transform.position;
    //    //    this.transform.rotation = MySnapZone.transform.rotation;
    //    //}
    //}
    //} 
    #endregion
}
