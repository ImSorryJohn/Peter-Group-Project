using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public void SelectEnemy()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMachine>().Input2(EnemyPrefab);
        
    }
        
    
}
