// CardEntity.cs
//
// �J�[�h�̏����������݂܂�
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
    // �R���X�g���N�^�͕s�v�iScriptableObject�ł͎g��Ȃ��j
}
