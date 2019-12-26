using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionNode : MonoBehaviour
{

    private void OnMouseDown()
    {
        if (SelectionScript.instance.SelectedObject)
        {
            SelectionScript.instance.SelectedObject.GetComponent<SelectionNode>().DisableSelectionOutline();
        }

        SelectionScript.instance.SelectedObject = gameObject;

        ShowSelectionOutline();
    }
    public void ShowSelectionOutline()
    {

    }

    public void DisableSelectionOutline()
    {

    }
}
