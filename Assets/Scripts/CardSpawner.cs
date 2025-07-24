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


    public void SpawnCard()
    {
        int index = UnityEngine.Random.Range(0, cardDataList.Count);

        Card card = Instantiate(cardPrefab, playerHandTransform); // 最初は手札に出す
        card.SetEntity(cardDataList[index]);

        // ドラッグ後に PlayerField に移動できるように設定
        card.GetComponent<CardMovement>().SetDropTarget(playerFieldTransform); // ドラッグ後に移動できるようにする
        CardMovement movement = card.GetComponent<CardMovement>();
        movement.SetCanvas(mainCanvas);
        movement.SetDropTarget(playerFieldTransform);
    }

    private void Start()
    {
        Debug.Log("CardSpawner Start() 呼び出し！: " + gameObject.name);

        for (int i = 0; i < 5; i++)
        {
            Debug.Log("SpawnCard #" + (i + 1));
            SpawnCard();
        }
    }

}
