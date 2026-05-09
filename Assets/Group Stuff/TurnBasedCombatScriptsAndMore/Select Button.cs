using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private bool showSelector;
    private GameObject Selector;
    public void SelectEnemy()
    {
       // GameObject.FindWithTag ("BattleManager").GetComponent<BattleStateMachine> ().Input2(EnemyPrefab);  
    }
        
    public void HideSelector()
    {
            EnemyPrefab.transform.Find("Selector").gameObject.SetActive(false);
        
    }

      public void ShowSelector()
    {
            EnemyPrefab.transform.Find("Selector").gameObject.SetActive(true);
        
    }
}
