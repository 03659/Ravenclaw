// DropPlace
//
// フィールドに置く処理を行います
//
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// フィールドにアタッチするクラス
public class DropPlace : MonoBehaviour , IDropHandler
{
    // ドロップされた時に行う処理
    public void OnDrop(PointerEventData eventData)
    {
        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();

        // もしカードがある場合、カードの親要素を自分にする
        if(card  != null)
        {
            card.cardParent = this.transform;
        }
    }
}
