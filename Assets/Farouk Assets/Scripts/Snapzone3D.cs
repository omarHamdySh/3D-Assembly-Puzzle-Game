using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZone3D : MonoBehaviour
{
    [SerializeField]
    private string dragObjectTag ;
    private void OnTriggerStay(Collider collision)
    {

        if (!collision.GetComponent<moveByDrag>().dragged && collision.gameObject.tag == dragObjectTag)
        {
            collision.transform.position = transform.position;
        }
    }
}
