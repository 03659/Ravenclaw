// CardMovement
//
// �J�[�h�𓮂����������s���܂�
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

        Debug.Log("CardSpawner Awake() �Ăяo���I: " + gameObject.name);

        if (canvas == null)
        {
            Debug.LogError("Canvas ���擾�ł��܂���ICard: " + gameObject.name);
        }
        else
        {
            Debug.Log("Canvas �擾����: " + canvas.name);
        }

        if (rectTransform == null)
        {
            Debug.LogError("RectTransform ���擾�ł��܂���ICard: " + gameObject.name);
        }
        else
        {
            Debug.Log("RectTransform �擾����: " + rectTransform.name);
        }
}

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        originalPosition = GetComponent<RectTransform>().anchoredPosition;

        canvasGroup.blocksRaycasts = false;
        // �}�E�X�ʒu�����[�J�����W�ɕϊ�
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint
            );
        // �I�t�Z�b�g���L�^�i�J�[�h�̈ʒu - �}�E�X�ʒu�j
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

