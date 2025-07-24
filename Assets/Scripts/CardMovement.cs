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

    private Transform playerFieldTransform; // �� SerializeField ���O���I
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
            // �I�t�Z�b�g�������ăJ�[�h�̈ʒu���X�V
            rectTransform.anchoredPosition = localPoint + offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (playerFieldTransform == null)
        {
            Debug.LogError("playerFieldTransform �� null�I");
            return;
        }

        // �����Ő�����������
        if (playerFieldTransform.childCount >= 3)
        {
            Debug.Log("PlayerField �͂��ł�3���̃J�[�h���u����Ă��܂��I");
            // ���̈ʒu�ɖ߂��i��D�Ȃǁj
            transform.SetParent(originalParent, false);
            return;
        }

        // �h���b�v���� �� PlayerField �Ɉړ�
        transform.SetParent(playerFieldTransform, false);
        transform.localScale = Vector3.one;
        transform.SetSiblingIndex(playerFieldTransform.childCount - 1);
    }

    public void SetCanvas(Canvas c)
    {
        canvas = c;
    }

}

