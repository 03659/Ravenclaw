// CardEntity.cs
//
// ƒJ[ƒh‚Ìî•ñ‚ğ‘‚«‚İ‚Ü‚·
//
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "CardEntity" , menuName = "Create CardEntity")]

public class CardEntity : ScriptableObject
{
    public int cardId;
    public new string name;
    public int cost;
    public int power;
    public Sprite icon;
    public int hp;
}
