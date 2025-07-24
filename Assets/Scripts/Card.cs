using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public Image cardImageUI;
    public Text cardNameText;
    public Text attackPowerText;
    public Text hpText;

    public void SetEntity(CardEntity entity)
    {
        if (entity == null)
        {
            Debug.LogError("entity �� null�I");
            return;
        }

        if (cardNameText == null) Debug.LogError("cardNameText �� null�I");
        if (attackPowerText == null) Debug.LogError("attackPowerText �� null�I");
        if (hpText == null) Debug.LogError("hpText �� null�I");
        if (cardImageUI == null) Debug.LogError("cardImageUI �� null�I");
        if (entity.cardImage == null) Debug.LogError("entity.cardImage �� null�I");
        if (entity.cardName == null) Debug.LogError("entity.cardName �� null�I");
    }
}
