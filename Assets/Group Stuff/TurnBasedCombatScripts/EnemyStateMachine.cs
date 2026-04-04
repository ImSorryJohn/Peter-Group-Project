using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{

    private BattleStateMachine BSM;
    public BaseEnemy enemy;

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
                break;
            case TurnState.WAITING:
                break;
            case TurnState.SELECTING:
                break;
            case TurnState.ACTION:
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
        myAttack.AttackersGameObject = this.gameObject;
        myAttack.AttackersTarget = BSM.PlayerInBattle[Random.Range(0, BSM.PlayerInBattle.Count)];
        BSM.PerformList.Add(myAttack);
    }
}
