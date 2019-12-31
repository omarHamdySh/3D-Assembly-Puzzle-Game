using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    #region Singleton
    public static SelectionManager instance { private set; get; }
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [HideInInspector] public GameObject selectedObject;

    public void selectThis(GameObject selectedObject)
    {
        this.selectedObject = selectedObject;
    }
    public void deselectThis(GameObject selectedObject)
    {
        if (this.selectedObject = selectedObject)
        {
            this.selectedObject = null;
        }
    }
}
