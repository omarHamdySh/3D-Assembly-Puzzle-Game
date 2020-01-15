using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionNode : MonoBehaviour
{
    public void select() {
        SelectionManager.instance.selectedObject = gameObject;
    }

}
