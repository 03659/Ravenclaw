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

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("DropPlace �ɃJ�[�h���h���b�v����܂���: " + gameObject.name);

        if (canvas == null || rectTransform == null)
        {
            Debug.LogError("canvas �܂��� rectTransform �� null �ł��I");
            return;
        }

        // �h���b�v���ꂽ�I�u�W�F�N�g���擾
        GameObject droppedCard = eventData.pointerDrag;

        if (droppedCard != null)
        {
            droppedCard.transform.SetParent(transform, false);
            droppedCard.transform.SetSiblingIndex(transform.childCount - 1);
            Debug.Log("�J�[�h�� DropPlace �ɔz�u���܂���: " + droppedCard.name);
        }
    }
}
