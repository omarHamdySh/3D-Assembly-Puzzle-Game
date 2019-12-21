using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitFollow : MonoBehaviour
{
    public GameObject objectToFollow;
    public bool isFollowingObject;

    // Update is called once per frame
    void Update()
    {
        if (isFollowingObject)
        {
            this.transform.position = objectToFollow.transform.position;
        }
    }
}
