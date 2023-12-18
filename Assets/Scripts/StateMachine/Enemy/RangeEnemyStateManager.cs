using UnityEngine;

public class RangeEnemyStateManager : StateManager<RangeEnemyStateManager.RangeEnemyStates>
{
    public RangeEnemy _rangeEnemy;

    public enum RangeEnemyStates
    {
        RangePatrolState,
        RangeChaseState,
        RangeAttackState
    }
    void Awake()
    {
        States.Add(RangeEnemyStates.RangePatrolState, new RangePatrolState(RangeEnemyStates.RangePatrolState));
        States.Add(RangeEnemyStates.RangeChaseState, new RangeChaseState(RangeEnemyStates.RangeChaseState));
        States.Add(RangeEnemyStates.RangeAttackState, new RangeAttackState(RangeEnemyStates.RangeAttackState));

        currentState = States[RangeEnemyStates.RangePatrolState];
    }

    void Update()
    {
        RangeEnemyStates nextState = currentState.StateKey;

        if (_rangeEnemy.distance > 25)
        {
            nextState = RangeEnemyStates.RangePatrolState;
        }
        else if (_rangeEnemy.distance < 25 && _rangeEnemy.distance > 10)
        {
            nextState = RangeEnemyStates.RangeChaseState;

            if (_rangeEnemy != null && _rangeEnemy.target != null)
            {
                Vector3 direction = _rangeEnemy.target.position - _rangeEnemy.transform.position;
                direction.Normalize();
                _rangeEnemy.transform.Translate(direction * _rangeEnemy.speed * Time.fixedDeltaTime);
            }
        }
        else if (_rangeEnemy.distance < 10)
        {
            nextState = RangeEnemyStates.RangeAttackState;
        }

        if (!currentState.StateKey.Equals(nextState))
        {
            ChangeState(nextState);
        }
    }
}
