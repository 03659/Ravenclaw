using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private Card cardPrefab;
    [SerializeField] private Transform cardParent;
    [SerializeField] private Transform playerFieldTransform;
    [SerializeField] private Transform playerHandTransform;
    [SerializeField] public List<CardEntity> cardDataList = new List<CardEntity>();
    [SerializeField] private Canvas mainCanvas;
    private int index;

    public void SpawnCard()
    {
        Card newCard = Instantiate(cardPrefab, playerHandTransform);
        newCard.SetEntity(cardDataList[index]);

        CardMovement movement = newCard.GetComponent<CardMovement>();
        movement.SetCanvas(mainCanvas);
        movement.SetDropTarget(playerFieldTransform);
    }

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("CardSpawner Start() ���Ă΂�܂���");

            int dataIndex = i % cardDataList.Count; // 0,1,2,0,1 �̂悤�Ƀ��[�v
            SpawnCard(dataIndex);
        }
    }

    private void SpawnCard(int i)
    {
        if (i < 0 || i >= cardDataList.Count)
        {
            Debug.LogWarning("�J�[�h�f�[�^�����݂��܂���: index = " + i);
            return;
        }

        Card newCard = Instantiate(cardPrefab, playerHandTransform);
        newCard.SetEntity(cardDataList[i]);

        CardMovement movement = newCard.GetComponent<CardMovement>();
        movement.SetCanvas(mainCanvas);
        movement.SetDropTarget(playerFieldTransform);

        Debug.Log("�J�[�h��������: " + newCard.name + " �� PlayerField�^�[�Q�b�g: " + playerFieldTransform.name);
    }
}
