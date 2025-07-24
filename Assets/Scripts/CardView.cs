// CardView.cs
//
// �J�[�h�̏����擾���A���f���܂�
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
            Debug.LogError("canvas �܂��� rectTransform �� null�ICard: " + gameObject.name);
        }
        else
        {
            Debug.Log("Canvas: " + canvas.name + ", RectTransform: " + rectTransform.name);
        }
    }

    // �J�[�h�̃f�[�^�̎擾�Ɣ��f
    public void Show(CardModel cardModel)
    {
        if (cardModel == null)
        {
            Debug.LogError("cardModel �� null �ł��I");
            return;
        }

        Debug.Log("cardModel.cardImage: " + cardModel.cardImage);
        Debug.Log("cardModel.cardName: " + cardModel.cardName);


        if (cardModel.cardImage == null) Debug.LogError("cardImage �� null�I");
        if (cardModel.cardName == null) Debug.LogError("cardName �� null�I");
        if (iconImage == null) Debug.LogError("iconImage �� Inspector �Ŋ��蓖�Ă��Ă��܂���I");
        if (nameText == null) Debug.LogError("nameText �� Inspector �Ŋ��蓖�Ă��Ă��܂���I");
        if (cardModel.cardImage == null) Debug.LogError("cardModel.cardImage �� null�I");
        if (cardModel.cardName == null) Debug.LogError("cardModel.cardName �� null�I");

        nameText.text = cardModel.cardName;
        powerText.text = cardModel.attackPower.ToString();
        costText.text = cardModel.cost.ToString();
        hpText.text = cardModel.hp.ToString();
        iconImage.sprite = cardModel.cardImage;
    }
}
