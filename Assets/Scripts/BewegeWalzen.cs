using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BewegeWalzen : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    bool move;
    public void OnPointerMove(PointerEventData eventData)
    {
        if(move) transform.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        move = false;

    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        move = true;
        Debug.Log("Clicked");
    }
}
