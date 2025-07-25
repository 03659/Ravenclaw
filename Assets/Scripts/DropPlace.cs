// DropPlace.cs
//
// �t�B�[���h�ɒu���������s���܂�
//
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// �t�B�[���h�ɃA�^�b�`����N���X
public class DropPlace : MonoBehaviour , IDropHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    public Transform cardContainer; // �� �����ɃJ�[�h��u��
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
            Debug.LogWarning("�h���b�v���ꂽ�J�[�h�� null �ł�");
            return;
        }

        CardMovement movement = droppedCard.GetComponent<CardMovement>();
        if (movement == null)
        {
            Debug.LogWarning("CardMovement �R���|�[�l���g��������܂���");
            return;
        }

        // PlayerField �ɂ��ł�3�����邩�`�F�b�N
        if (cardContainer.childCount >= 3)
        {
            Debug.Log("PlayerField �͖��t�ł��I�J�[�h�����ɖ߂��܂�");

            droppedCard.transform.SetParent(movement.originalParent, false);
            droppedCard.GetComponent<RectTransform>().anchoredPosition = movement.originalPosition;

            Debug.Log("�J�[�h��߂��܂���: " + droppedCard.name);

            return;
        }

        // �h���b�v���� �� PlayerField �Ɉړ�
        droppedCard.transform.SetParent(cardContainer, false);
        droppedCard.transform.SetAsLastSibling();
        droppedCard.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        Debug.Log("�J�[�h�� PlayerField �ɔz�u���܂���: " + droppedCard.name);
    }
}
