using UnityEngine;
using System.Collections;
[System.Serializable]

public class BaseEnemy: BaseClass
{
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
}