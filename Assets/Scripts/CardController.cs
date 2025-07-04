// CardController.cs
//
// カードデータの処理
//
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour
{
    // カードの見た目処理
    public CardView view;

    // カードのデータの処理
    public CardModel model;

    private void Awake()
    {
        view = GetComponent<CardView>();
    }
    
    // カードを生成したときに呼ばれる関数
    public void Init(int cardID)
    {
        // カードデータを生成
        model = new CardModel(cardID);

        // 表示
        view.Show(model);
    }
}
