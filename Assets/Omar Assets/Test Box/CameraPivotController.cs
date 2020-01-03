using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivotController : MonoBehaviour
{
    public bool isFollowingSelectedObject = true;
    private void Update()
    {
        if (SelectionManager.instance.selectedObject && isFollowingSelectedObject  )
        {
            if (!SelectionManager.instance.selectedObject.GetComponent<Drage3DObjects>().isDragged)
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
        else
        {
            this.resetFocus();
        }
    }

    public void resetFocus()
    {
        this.transform.position = Vector3.zero;
        isFollowingSelectedObject = false;
    }

    public void resetToFrontView() {
        isFollowingSelectedObject = false;
        this.transform.position = Vector3.zero;
        this.transform.rotation = Quaternion.identity;
    }



}
