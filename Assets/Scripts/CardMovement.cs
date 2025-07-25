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

    public Transform playerFieldTransform;
    public Transform originalParent;
    public Vector2 originalPosition;

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
        originalParent = transform.parent;
        originalPosition = GetComponent<RectTransform>().anchoredPosition;

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

        originalParent = transform.parent;

        canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint
        );

        rectTransform.anchoredPosition = localPoint + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }

    public void SetCanvas(Canvas c)
    {
        canvas = c;
    }

}

