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
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 offset;

    private Transform playerFieldTransform; // ← SerializeField を外す！
    private Transform originalParent;

    public void SetDropTarget(Transform target)
    {
        playerFieldTransform = target;
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        Debug.Log("CardSpawner Awake() 呼び出し！: " + gameObject.name);

        if (canvas == null)
        {
            Debug.LogError("Canvas が取得できません！Card: " + gameObject.name);
        }
        else
        {
            Debug.Log("Canvas 取得成功: " + canvas.name);
        }

        if (rectTransform == null)
        {
            Debug.LogError("RectTransform が取得できません！Card: " + gameObject.name);
        }
        else
        {
            Debug.Log("RectTransform 取得成功: " + rectTransform.name);
        }
}

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        // マウス位置をローカル座標に変換
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint
            );
        // オフセットを記録（カードの位置 - マウス位置）
        offset = rectTransform.anchoredPosition - localPoint;

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint))
        {
            // オフセットを加えてカードの位置を更新
            rectTransform.anchoredPosition = localPoint + offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (playerFieldTransform == null)
        {
            Debug.LogError("playerFieldTransform が null！");
            return;
        }

        // ここで制限をかける
        if (playerFieldTransform.childCount >= 3)
        {
            Debug.Log("PlayerField はすでに3枚のカードが置かれています！");
            // 元の位置に戻す（手札など）
            transform.SetParent(originalParent, false);
            return;
        }

        // ドロップ成功 → PlayerField に移動
        transform.SetParent(playerFieldTransform, false);
        transform.localScale = Vector3.one;
        transform.SetSiblingIndex(playerFieldTransform.childCount - 1);
    }

    public void SetCanvas(Canvas c)
    {
        canvas = c;
    }

}

