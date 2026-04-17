using UnityEngine;
using System.Collections;

public class EnemyStateMachine : MonoBehaviour
{

    private BattleStateMachine BSM;
    public BaseEnemy enemy;
    private EnemyStateMachine currentEnemy;

    public enum TurnState
    {
        PROCESSING,
        CHOOSEACTION,
        WAITING,
        SELECTING,
        ACTION,
        DEAD
    }
    public TurnState currentState;
    private float currentCooldown = 0f;
    private float maxCooldown = 5f;
    private Vector3 startPosition;
    public GameObject HeroToAttack;
    private bool actionStarted = false;
    private float animSpeed = 5f;
    void Start()
    {
        currentState = TurnState.PROCESSING;
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case TurnState.PROCESSING:
                UpdateProgressBar();
                break;
            case TurnState.CHOOSEACTION:
                ChooseAction();
                currentState = TurnState.WAITING;
                break;
            case TurnState.WAITING:
                break;
            case TurnState.SELECTING:
                break;
            case TurnState.ACTION:
                    StartCoroutine(TimeForAction());
                break;
            case TurnState.DEAD:
                break;
        }
    }

    private void UpdateProgressBar()
    {
        currentCooldown = currentCooldown + Time.deltaTime;
        if (currentCooldown >= maxCooldown)
        {
            currentState = TurnState.CHOOSEACTION;
        }
    }

    void ChooseAction()
    {
        HandleTurns myAttack = new HandleTurns();
        myAttack.Attacker = enemy.name;
        myAttack.Type = "Enemy";
        myAttack.AttackersGameObject = this.gameObject;
        myAttack.AttackersTarget = BSM.PlayerInBattle[Random.Range(0, BSM.PlayerInBattle.Count)];
        BSM.PerformList.Add(myAttack);
    }

    private IEnumerator TimeForAction()
    {
        if (actionStarted)
        {
            yield break;
        }
        actionStarted = true;
        //animate the enemy near the playe
        Vector3 heroPosition = new Vector3(HeroToAttack.transform.position.x-1.5f, HeroToAttack.transform.position.y, HeroToAttack.transform.position.z);
        while (MoveTowardsEnemy(heroPosition))
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
