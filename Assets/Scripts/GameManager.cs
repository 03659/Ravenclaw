// GameManager.cs
//
// �J�[�h�������������s���܂�
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

        Debug.Log("GameManager �N��: " + gameObject.name);
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
            CreateCard(i); // �J�[�hID�ɉ����Đ���
        }

        Debug.Log("cardPrefab: " + cardPrefab);

        if (cardPrefab == null)
        {
            Debug.LogError("cardPrefab �� null�I�J�[�h�����ł��܂���I");
            return;
        }

        CardController card = Instantiate(cardPrefab, cardParent);
        card.Init(cardID);

    }

    void CreateCard(int cardID, Transform place)
    {
        Debug.Log("CreateCard �J�n�F" + cardID);

        if (cardPrefab == null)
        {
            Debug.LogError("cardPrefab �� null�I�J�[�h�����ł��܂���I");
            return;
        }

        CardController card = Instantiate(cardPrefab, place);
        card.Init(cardID);

        card.Init(cardID);
        Debug.Log("Init �Ăяo������");

    }

    public void CreateCard(int cardID)
    {
        CardController card = Instantiate(cardPrefab, cardParent);
        card.Init(cardID);
    }

}   // Grid �O���[�v�����Ă���