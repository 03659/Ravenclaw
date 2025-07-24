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
            Debug.LogError("entity が null！");
            return;
        }

        if (cardNameText == null) Debug.LogError("cardNameText が null！");
        if (attackPowerText == null) Debug.LogError("attackPowerText が null！");
        if (hpText == null) Debug.LogError("hpText が null！");
        if (cardImageUI == null) Debug.LogError("cardImageUI が null！");
        if (entity.cardImage == null) Debug.LogError("entity.cardImage が null！");
        if (entity.cardName == null) Debug.LogError("entity.cardName が null！");
    }
}
