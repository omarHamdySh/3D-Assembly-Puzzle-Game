using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitFollow : MonoBehaviour
{
    public bool isFollowingObject;

    // Update is called once per frame
    void Update()
    {
        if (isFollowingObject && SelectionScript.instance.SelectedObject)
        {
            this.transform.position = SelectionScript.instance.SelectedObject.transform.position;
        }
    }
}
