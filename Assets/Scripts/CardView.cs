// CardView.cs
//
// カードの情報を取得し、反映します
//
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class CardView : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text powerText;
    [SerializeField] private Text costText;
    [SerializeField] private Text hpText;
    [SerializeField] private Image iconImage;

    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        if (canvas == null)
        {
            canvas = GetComponentInParent<Canvas>();
        }

        if (canvas == null || rectTransform == null)
        {
            Debug.LogError("canvas または rectTransform が null！Card: " + gameObject.name);
        }
        else
        {
            Debug.Log("Canvas: " + canvas.name + ", RectTransform: " + rectTransform.name);
        }
    }

    // カードのデータの取得と反映
    public void Show(CardModel cardModel)
    {
        if (cardModel == null)
        {
            Debug.LogError("cardModel が null です！");
            return;
        }

        Debug.Log("cardModel.cardImage: " + cardModel.cardImage);
        Debug.Log("cardModel.cardName: " + cardModel.cardName);


        if (cardModel.cardImage == null) Debug.LogError("cardImage が null！");
        if (cardModel.cardName == null) Debug.LogError("cardName が null！");
        if (iconImage == null) Debug.LogError("iconImage が Inspector で割り当てられていません！");
        if (nameText == null) Debug.LogError("nameText が Inspector で割り当てられていません！");
        if (cardModel.cardImage == null) Debug.LogError("cardModel.cardImage が null！");
        if (cardModel.cardName == null) Debug.LogError("cardModel.cardName が null！");

        nameText.text = cardModel.cardName;
        powerText.text = cardModel.attackPower.ToString();
        costText.text = cardModel.cost.ToString();
        hpText.text = cardModel.hp.ToString();
        iconImage.sprite = cardModel.cardImage;
    }
}
