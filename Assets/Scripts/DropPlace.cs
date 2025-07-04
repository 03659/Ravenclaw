// DropPlace
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
    // �h���b�v���ꂽ���ɍs������
    public void OnDrop(PointerEventData eventData)
    {
        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();

        // �����J�[�h������ꍇ�A�J�[�h�̐e�v�f�������ɂ���
        if(card  != null)
        {
            card.cardParent = this.transform;
        }
    }
}
