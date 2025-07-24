// CardController.cs
//
// カードデータの処理
//
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Assertions;

public class CardController : MonoBehaviour
{
    // カードの見た目処理
    public CardView view;

    // カードのデータの処理
    public CardModel model;

    private void Awake()
    {
        view = GetComponent<CardView>();

        if (view == null)
        {
            Debug.LogError("CardView を取得できませんでした！");
        }
    }
    
    // カードを生成したときに呼ばれる関数
    public void Init(int cardID)
    {
        model = new CardModel(cardID);
        view.Show(model);
    }
}
