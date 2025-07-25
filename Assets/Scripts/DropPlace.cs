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
    public Transform cardContainer; // ← ここにカードを置く
    public Vector2 originalPosition;

    void Start()
    {
        if (cardContainer == null)
        {
            cardContainer = this.transform;
        }
    }

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedCard = eventData.pointerDrag;

        if (droppedCard == null)
        {
            Debug.LogWarning("ドロップされたカードが null です");
            return;
        }

        CardMovement movement = droppedCard.GetComponent<CardMovement>();
        if (movement == null)
        {
            Debug.LogWarning("CardMovement コンポーネントが見つかりません");
            return;
        }

        // PlayerField にすでに3枚あるかチェック
        if (cardContainer.childCount >= 3)
        {
            Debug.Log("PlayerField は満杯です！カードを元に戻します");

            droppedCard.transform.SetParent(movement.originalParent, false);
            droppedCard.GetComponent<RectTransform>().anchoredPosition = movement.originalPosition;

            Debug.Log("カードを戻しました: " + droppedCard.name);

            return;
        }

        // ドロップ成功 → PlayerField に移動
        droppedCard.transform.SetParent(cardContainer, false);
        droppedCard.transform.SetAsLastSibling();
        droppedCard.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        Debug.Log("カードを PlayerField に配置しました: " + droppedCard.name);
    }
}
