using UnityEngine;
using System.Collections;

[System.Serializable]
public class HandleTurns 
{
    public string Attacker;
    public string Type;
    public GameObject AttackersGameObject;
    public GameObject AttackersTarget;

    public BaseAttack ChooseAttack;

    
}