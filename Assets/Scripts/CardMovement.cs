// CardMovement
//
// カードを動かす処理を行います
//
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour , IDragHandler , IBeginDragHandler , IEndDragHandler
{
    public Transform cardParent;

    // ドラッグするときの処理
    public void OnBeginDrag(PointerEventData eventData)
    {
        cardParent = transform.parent;
        transform.SetParent(cardParent.parent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    // ドラッグしたときに起きる処理
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    // カードを離したときに行う処理
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(cardParent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}

