using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivotController : MonoBehaviour
{
    public bool isFollowingSelectedObject = true;
    private void Update()
    {
        if (SelectionManager.instance.selectedObject && isFollowingSelectedObject)
        {
            this.transform.position = SelectionManager.instance.selectedObject.transform.position;
        }
    }

    public void focusOnSelected()
    {
        if (SelectionManager.instance.selectedObject)
        {
            this.transform.position = SelectionManager.instance.selectedObject.transform.position;
            isFollowingSelectedObject = true;
        }
        else {
            this.resetFocus();
        }
    }

    public void resetFocus()
    {
        this.transform.position = Vector3.zero;
        isFollowingSelectedObject = false;
    }


}
