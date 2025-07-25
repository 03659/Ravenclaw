using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform playerHandTransform;

    private int maxCards = 5;

    void Start()
    {
        //GenerateInitialCards();
    }

    void GenerateInitialCards()
    {
        if (playerHandTransform.childCount > 0)
        {
            Debug.Log("すでにカードが存在しています。生成をスキップします。");
            return;
        }

        for (int i = 0; i < maxCards; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, playerHandTransform);
            newCard.name = "Card_" + (i + 1);
        }
    }
}
