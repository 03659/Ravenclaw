// CardModel.cs
//
// �J�[�h�̏���ǂݍ��݂܂�
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
            Debug.LogError($"CardEntity �̓ǂݍ��ݎ��s�I�p�X: Resources/{path} �����݂��邩�m�F���Ă��������I");
            return;
        }

        cardId = cardID;
        cardName = entity.cardName;
        cost = entity.cost;
        attackPower = entity.attackPower;
        cardImage = entity.cardImage;
        hp = entity.hp;

        // �f�[�^�̑���icardEntity �̊e�t�B�[���h�� null �łȂ����Ƃ��m�F�j
    }

    /*cardId = cardEntity.cardId;
        name = cardEntity.name;
        cost = cardEntity.cost;
        power = cardEntity.power;
        icon = cardEntity.icon;
        hp = cardEntity.hp;*/
}


