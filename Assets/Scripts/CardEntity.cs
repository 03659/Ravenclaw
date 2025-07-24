// CardEntity.cs
//
// カードの情報を書き込みます
//
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "CardEntity" , menuName = "Create CardEntity")]
    
public class CardEntity : ScriptableObject
{
    public string cardName;
    public Sprite cardImage;
    public int attackPower;
    public int hp;
    public int cost;
    // コンストラクタは不要（ScriptableObjectでは使わない）
}
