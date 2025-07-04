// CardController.cs
//
// �J�[�h�f�[�^�̏���
//
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour
{
    // �J�[�h�̌����ڏ���
    public CardView view;

    // �J�[�h�̃f�[�^�̏���
    public CardModel model;

    private void Awake()
    {
        view = GetComponent<CardView>();
    }
    
    // �J�[�h�𐶐������Ƃ��ɌĂ΂��֐�
    public void Init(int cardID)
    {
        // �J�[�h�f�[�^�𐶐�
        model = new CardModel(cardID);

        // �\��
        view.Show(model);
    }
}
