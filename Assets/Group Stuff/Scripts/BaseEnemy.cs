using UnityEngine;
using System.Collections;
[System.Serializable]

public class BaseEnemy
{
   public string name;
    public enum type
    {
            HUMAN,
            UNDEAD,
            ANIMAL,
            GHOST
    }
    public enum rarity
    {
            common,
            uncommon,
            rare,
            superrare
    }
    public type EnemyTyping;
    public rarity Rarity;
    public float baseHP;
    public float curHP;
    public float baseMP;
    public float curMP;
    public float baseATK;
    public float curATK;
    public float baseDEF;
    public float curDEF;
}
