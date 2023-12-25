public class RangeEnemyStateManager : StateManager<RangeEnemyStateManager.RangeEnemyStates>
{
    public RangeEnemy _rangeEnemy;
    public EnemyShooter enemyShooter;

    public enum RangeEnemyStates
    {
        RangePatrolState,
        RangeChaseState,
        RangeAttackState
    }
    void Awake()
    {
        States.Add(RangeEnemyStates.RangePatrolState, new RangePatrolState(RangeEnemyStates.RangePatrolState, _rangeEnemy));
        States.Add(RangeEnemyStates.RangeChaseState, new RangeChaseState(RangeEnemyStates.RangeChaseState, _rangeEnemy));
        States.Add(RangeEnemyStates.RangeAttackState, new RangeAttackState(RangeEnemyStates.RangeAttackState, _rangeEnemy, enemyShooter));

        currentState = States[RangeEnemyStates.RangePatrolState];
    }

    void Update()
    {
        RangeEnemyStates nextState = currentState.StateKey;

        UpdateCurrentState();

        if (_rangeEnemy.playerDistance > 20)
        {
            nextState = RangeEnemyStates.RangePatrolState;
        } else if (_rangeEnemy.playerDistance < 20 && _rangeEnemy.playerDistance > 10)
        {
            nextState = RangeEnemyStates.RangeChaseState;
        } else if (_rangeEnemy.playerDistance < 10)
        {
            nextState = RangeEnemyStates.RangeAttackState;
        }

        if (!currentState.StateKey.Equals(nextState))
        {
            ChangeState(nextState);
        }
    }

    void UpdateCurrentState()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }
}
