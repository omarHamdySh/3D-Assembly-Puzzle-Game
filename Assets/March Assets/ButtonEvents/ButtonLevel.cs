using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLevel : MonoBehaviour ,IPointerDownHandler, IPointerUpHandler
{
    public GameLevelsNames currentLevel;
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        GameManager.Instance.currentLevel = currentLevel;
    }
}
