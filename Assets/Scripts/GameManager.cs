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
    [SerializeField] CardController cardPrefab;
    [SerializeField] Transform playerHand, playerField;

    private void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        CardController card = Instantiate(cardPrefab, playerHand);
        card.Init(1);
        CardController card2 = Instantiate(cardPrefab, playerHand);
        card2.Init(2);
        CardController card3 = Instantiate(cardPrefab, playerHand);
        card3.Init(2);
        CardController card4 = Instantiate(cardPrefab, playerHand);
        card4.Init(1);
        CardController card5 = Instantiate(cardPrefab, playerField);
        card5.Init(2);
        CardController card6 = Instantiate(cardPrefab, playerField);
        card6.Init(1);
    }

    void CreateCard(int cardID, Transform place)
    {
        CardController card = Instantiate(cardPrefab, place);
        card.Init(cardID);
    }
}
