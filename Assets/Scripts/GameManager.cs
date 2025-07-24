// GameManager.cs
//
// カードを引く処理を行います
//
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CardController cardPrefab;
    [SerializeField] Transform playerHand;
    [SerializeField] private Transform cardParent;
    private int cardID;

    private void Start()
    {
        StartGame();

        Debug.Log("GameManager Start: cardPrefab = " + cardPrefab);
        StartGame();

        Debug.Log("GameManager 起動: " + gameObject.name);
        Debug.Log("cardPrefab: " + cardPrefab);
        StartGame();
    }

    private void StartGame()
    {
        CreateCard(1, playerHand);
        CreateCard(2, playerHand);
        CreateCard(2, playerHand);
        CreateCard(1, playerHand);

        for (int i = 0; i < 3; i++)
        {
            CreateCard(i); // カードIDに応じて生成
        }

        Debug.Log("cardPrefab: " + cardPrefab);

        if (cardPrefab == null)
        {
            Debug.LogError("cardPrefab が null！カード生成できません！");
            return;
        }

        CardController card = Instantiate(cardPrefab, cardParent);
        card.Init(cardID);

    }

    void CreateCard(int cardID, Transform place)
    {
        Debug.Log("CreateCard 開始：" + cardID);

        if (cardPrefab == null)
        {
            Debug.LogError("cardPrefab が null！カード生成できません！");
            return;
        }

        CardController card = Instantiate(cardPrefab, place);
        card.Init(cardID);

        card.Init(cardID);
        Debug.Log("Init 呼び出し成功");

    }

    public void CreateCard(int cardID)
    {
        CardController card = Instantiate(cardPrefab, cardParent);
        card.Init(cardID);
    }

}   // Grid グループを入れておく