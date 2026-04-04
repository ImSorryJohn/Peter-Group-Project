using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BattleStateMachine : MonoBehaviour
{
    public enum PerformAction
    {
        WAIT,
        TAKEACTION,
        PERFORMACTION,
        CHECKALIVE,
    }

    public PerformAction battleStates;
    public List<HandleTurns> PerformList = new List<HandleTurns>();
    public List<GameObject> PlayerInBattle = new List<GameObject>();
    public List<GameObject> EnemyInBattle = new List<GameObject>();
    
    
    // Start is called once  the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        battleStates = PerformAction.WAIT;
        EnemyInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        PlayerInBattle.AddRange(GameObject.FindGameObjectsWithTag("Player"));
    }

    // Update is called once per frame
    void Update()
    {
        switch (battleStates)
        {
            case PerformAction.WAIT:
                // code for waiting
                break;
            case PerformAction.TAKEACTION:
                // code for taking action
                break;
            case PerformAction.PERFORMACTION:
                // code for performing action
                break;
            case PerformAction.CHECKALIVE:
                // code for checking if alive
                break;
        }
    }

    public void CollectActions(HandleTurns input)
    {
        PerformList.Add(input);
    }
}
