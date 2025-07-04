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
    public Transform cardParent;

    // �h���b�O����Ƃ��̏���
    public void OnBeginDrag(PointerEventData eventData)
    {
        cardParent = transform.parent;
        transform.SetParent(cardParent.parent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    // �h���b�O�����Ƃ��ɋN���鏈��
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    // �J�[�h�𗣂����Ƃ��ɍs������
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(cardParent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}

