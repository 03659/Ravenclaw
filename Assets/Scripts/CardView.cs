// CardView.cs
//
// �J�[�h�̏����擾���A���f���܂�
//
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] TextMeshPro nameText, powerText, costText, hpText;
    [SerializeField] Image iconImage;

    // �J�[�h�̃f�[�^�̎擾�Ɣ��f
    public void Show(CardModel cardModel)
    {
        nameText.text = cardModel.name;
        powerText.text = cardModel.power.ToString();
        costText.text = cardModel.cost.ToString();
        iconImage.sprite = cardModel.icon;
        hpText.text = cardModel.hp.ToString();
    }
}
