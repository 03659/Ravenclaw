// CardController.cs
//
// �J�[�h�f�[�^�̏���
//
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Assertions;

public class CardController : MonoBehaviour
{
    // �J�[�h�̌����ڏ���
    public CardView view;

    // �J�[�h�̃f�[�^�̏���
    public CardModel model;

    private void Awake()
    {
        view = GetComponent<CardView>();

        if (view == null)
        {
            Debug.LogError("CardView ���擾�ł��܂���ł����I");
        }
    }
    
    // �J�[�h�𐶐������Ƃ��ɌĂ΂��֐�
    public void Init(int cardID)
    {
        model = new CardModel(cardID);
        view.Show(model);
    }
}
