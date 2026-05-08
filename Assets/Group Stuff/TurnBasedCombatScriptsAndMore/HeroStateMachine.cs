using UnityEngine;
using System.Collections;   
using UnityEngine.UI;
using System;
public class HeroStateMachine : MonoBehaviour
{
    private BattleStateMachine BSM;
    public BaseHero hero;

    public enum TurnState
    {
        PROCESSING,
        ADDTOLIST,
        WAITING,
        SELECTING,
        ACTION,
        DEAD
    }

    public TurnState currentState;
    private float currentCooldown = 0f;
    private float maxCooldown = 5f;
    public Image ProgressBar;
    public GameObject Selector;
    public GameObject EnemyToAttack;
    private float animSpeed = 5f;
    private bool actionStarted = false;
    private Vector3 startPosition;


    void Start()
    {
        startPosition = transform.position;
        currentCooldown = 0f + hero.Agility;
        currentState = TurnState.PROCESSING;
        Selector.SetActive(false);
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log (currentState);
        switch (currentState)
        {
            case TurnState.PROCESSING:
                UpdateProgressBar();
                break;
            case TurnState.ADDTOLIST:
                BSM.HeroesToManage.Add(this.gameObject);
                currentState = TurnState.WAITING;
                break;
            case TurnState.WAITING:

               break;
            case TurnState.ACTION:
                StartCoroutine(TimeForAction());

                break;
            case TurnState.DEAD:
                    currentCooldown = 0f;

                break;
        }
    }

    void UpdateProgressBar()
    {
        currentCooldown = currentCooldown + Time.deltaTime;
        float currentProgress = currentCooldown / maxCooldown;
        ProgressBar.transform.localScale = new Vector3(Mathf.Clamp(currentProgress, 0, 1), ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);
        if (currentCooldown >= maxCooldown)
        {
            currentState = TurnState.ADDTOLIST;
        }
    }

     private IEnumerator TimeForAction()
    {
        if (actionStarted)
        {
            yield break;
        }
        actionStarted = true;
        //animate the enemy near the playe
        Vector3 enemyPosition = new Vector3(EnemyToAttack.transform.position.x+1.5f, EnemyToAttack.transform.position.y, EnemyToAttack.transform.position.z);
        while (MoveTowardsEnemy(enemyPosition)) {yield return null;}
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        //animate the enemy back to start position
        Vector3 firstPosition = startPosition;
        while (MoveTowardsEnemy(firstPosition))
        {
            yield return null;
        }
        
        BSM.PerformList.RemoveAt(0);

        BSM.battleStates = BattleStateMachine.PerformAction.WAIT;

        actionStarted = false;
        currentCooldown = 0f;
        currentState = TurnState.PROCESSING;

    
    }

    private bool MoveTowardsEnemy(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }
    private bool MoveTowardsStart(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }

}
