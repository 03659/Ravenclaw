// CardModel.cs
//
// カードの情報を読み込みます
//
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardModel
{
    public int cardId;
    public string cardName;
    public int cost;
    public int attackPower;
    public Sprite cardImage;
    public int hp;

    public CardModel(int cardID)
    {

        string path = "CardEntityList/Card" + cardID;
        CardEntity entity = Resources.Load<CardEntity>(path);

        if (entity == null)
        {
            Debug.LogError($"CardEntity の読み込み失敗！パス: Resources/{path} が存在するか確認してください！");
            return;
        }

        cardId = cardID;
        cardName = entity.cardName;
        cost = entity.cost;
        attackPower = entity.attackPower;
        cardImage = entity.cardImage;
        hp = entity.hp;

        // データの代入（cardEntity の各フィールドが null でないことも確認）
    }

    /*cardId = cardEntity.cardId;
        name = cardEntity.name;
        cost = cardEntity.cost;
        power = cardEntity.power;
        icon = cardEntity.icon;
        hp = cardEntity.hp;*/
}


