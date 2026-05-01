using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Linq;
 

    

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
    
    
    public enum HeroGUI
    {
        ACTIVATE,
        WAITING,
        INPUT1,
        INPUT2,
        DONE
    }
    public HeroGUI HeroInput;

    public List<GameObject> HeroesToManage = new List<GameObject>(); 
    private HandleTurns HeroChoice;

    public GameObject enemyButton;
    public GameObject Spacer;
    public Transform SpacerTransform;
    public GameObject ActionPanel;
    public GameObject EnemySelectPanel;

    // Start is called once  the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        battleStates = PerformAction.WAIT;
        EnemyInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        PlayerInBattle.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        HeroInput = HeroGUI.ACTIVATE;
        ActionPanel.SetActive(false);
        EnemySelectPanel.SetActive(false);
        EnemyButtons();
    }

    // Update is called once per frame
    void Update()
    {
        switch (battleStates)
        {
            case PerformAction.WAIT:
                // code for waiting
                if(PerformList.Count > 0)
                {
                    battleStates = PerformAction.TAKEACTION;
                }
                break;
            case PerformAction.TAKEACTION:
                GameObject performer= GameObject.Find(PerformList[0].Attacker);
               if(PerformList[0].Type == "Enemy")                
               {
               EnemyStateMachine ESM = performer.GetComponent<EnemyStateMachine>();
                ESM.HeroToAttack = PerformList[0].AttackersTarget;   
               ESM.currentState = EnemyStateMachine.TurnState.ACTION;
                }
                if(PerformList[0].Type == "Player")
                {
                    Debug.Log("Player is attacking");
                    HeroStateMachine HSM = performer.GetComponent<HeroStateMachine>();
                   HSM.EnemyToAttack = PerformList[0].AttackersTarget;
                   HSM.currentState = HeroStateMachine.TurnState.ACTION;
                   }
                break;
            case PerformAction.PERFORMACTION:
                // code for performing action
                    break;
            case PerformAction.CHECKALIVE:
                // code for checking if alive
                break;
        }

        switch (HeroInput)
        {
            case (HeroGUI.ACTIVATE):
                // code for activating hero GUI
                if(HeroesToManage.Count > 0)
                {
                    HeroesToManage[0].transform.Find("Selector").gameObject.SetActive(true);
                    HeroChoice = new HandleTurns();
                    ActionPanel.SetActive(true);
                    HeroInput = HeroGUI.WAITING;
                }
                break;
            case (HeroGUI.WAITING):
                // code for waiting for player input    
                   
                break;
            case (HeroGUI.DONE):
                HeroInputDone();
                // code for finishing player input and removing from list
                break;
        }
    }

    public void CollectActions(HandleTurns input)
    {
        PerformList.Add(input);
    }
    void EnemyButtons()
    {
       foreach(GameObject enemy in EnemyInBattle)
        {
            GameObject newButton = Instantiate(enemyButton) as GameObject;
            SelectButton button = newButton.GetComponent<SelectButton>();
            button.EnemyPrefab = enemy;
            EnemyStateMachine currentEnemy = enemy.GetComponent<EnemyStateMachine>();    
//            TMP_Text buttonText = newButton.transform.Find("Text").gameObject.GetComponent<TMP_Text>();           
  //          buttonText.text = currentEnemy.enemy.name;
            button.EnemyPrefab = enemy;
            newButton.transform.SetParent(Spacer.transform, false);
        } 
  }

  public void Input1() //attackers button
  {
      HeroChoice.Attacker = HeroesToManage[0].name;
      HeroChoice.Type = "Player";
      HeroChoice.AttackersGameObject = HeroesToManage[0];
      ActionPanel.SetActive(false);
      EnemySelectPanel.SetActive(true);
  }
  public void Input2(GameObject chosenEnemy)
  {
      HeroChoice.AttackersTarget = chosenEnemy;
      HeroInput = HeroGUI.DONE;
  }
  void HeroInputDone()
    {
        PerformList.Add(HeroChoice);
        EnemySelectPanel.SetActive(false);
        HeroesToManage[0].transform.Find("Selector").gameObject.SetActive(false);;
        HeroesToManage.RemoveAt(0);
        HeroInput = HeroGUI.ACTIVATE;
    }
}
