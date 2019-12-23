using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    ItemSelection currentSelectedItem;


    public void selectOtherItem(ItemSelection currentItem) {
        currentSelectedItem.UnSelectThis();
        currentItem.selectThis();
        currentSelectedItem = currentItem;
    }

}
