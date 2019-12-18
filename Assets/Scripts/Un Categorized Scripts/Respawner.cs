using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public GameObject ComoundBoxPrefab;
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == ComoundBoxPrefab.gameObject.tag)
        {

            col.gameObject.GetComponentInChildren<Rigidbody>().isKinematic = false;
            Instantiate(ComoundBoxPrefab, new Vector3(-2.72f, 1.046f, 2.481f), Quaternion.identity);
        }
    }
}
