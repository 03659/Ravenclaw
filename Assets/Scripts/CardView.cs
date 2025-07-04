// CardView.cs
//
// カードの情報を取得し、反映します
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

    // カードのデータの取得と反映
    public void Show(CardModel cardModel)
    {
        nameText.text = cardModel.name;
        powerText.text = cardModel.power.ToString();
        costText.text = cardModel.cost.ToString();
        iconImage.sprite = cardModel.icon;
        hpText.text = cardModel.hp.ToString();
    }
}
