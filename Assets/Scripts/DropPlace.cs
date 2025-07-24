// DropPlace.cs
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
    private Canvas canvas;
    private RectTransform rectTransform;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("DropPlace にカードがドロップされました: " + gameObject.name);

        if (canvas == null || rectTransform == null)
        {
            Debug.LogError("canvas または rectTransform が null です！");
            return;
        }

        // ドロップされたオブジェクトを取得
        GameObject droppedCard = eventData.pointerDrag;

        if (droppedCard != null)
        {
            droppedCard.transform.SetParent(transform, false);
            droppedCard.transform.SetSiblingIndex(transform.childCount - 1);
            Debug.Log("カードを DropPlace に配置しました: " + droppedCard.name);
        }
    }
}
