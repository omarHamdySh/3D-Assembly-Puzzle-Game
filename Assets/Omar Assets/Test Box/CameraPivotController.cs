using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivotController : MonoBehaviour
{
    public void focusOnSelected()
    {
        if (SelectionManager.instance.selectedObject)
        {
            this.transform.position = SelectionManager.instance.selectedObject.transform.position;
        }
        else {
            this.resetFocus();
        }
    }

    public void resetFocus()
    {
        this.transform.position = Vector3.zero;
    }
}
