using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZone3D : MonoBehaviour
{
    private void OnTriggerStay(Collider collision)
    {

        if (/*!collision.GetComponent<moveByDrag>().dragged && */collision.gameObject.tag == gameObject.tag)
        {
            collision.transform.position = transform.position;
        }
    }
}
