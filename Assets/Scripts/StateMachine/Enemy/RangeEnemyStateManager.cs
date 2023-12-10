using UnityEngine;

public class RangeEnemyStateManager : StateManager<RangeEnemyStateManager.RangeEnemyStates>
{
    public RangeEnemy _rangeEnemy;

    public enum RangeEnemyStates
    {
        PatrolState,
        ChaseState,
        RangeAttackState
    }
    //void Awake()
    //{
    //    States.Add(RangeEnemyStates.PatrolState, new PatrolState(RangeEnemyStates.PatrolState));
    //    States.Add(RangeEnemyStates.ChaseState, new ChaseState(RangeEnemyStates.ChaseState));
    //    States.Add(RangeEnemyStates.RangeAttackState, new RangeAttackState(RangeEnemyStates.RangeAttackState));

    //    currentState = States[RangeEnemyStates.PatrolState];
    //}

    void Update()
    {
        RangeEnemyStates nextState = currentState.StateKey;

        if (_rangeEnemy.distance > 20)
        {
            nextState = RangeEnemyStates.PatrolState;
        }
        else if (_rangeEnemy.distance < 20 && _rangeEnemy.distance > 5)
        {
            nextState = RangeEnemyStates.ChaseState;

            if (_rangeEnemy != null && _rangeEnemy.target != null)
            {
                Vector3 direction = _rangeEnemy.target.position - _rangeEnemy.transform.position;
                direction.Normalize();
                _rangeEnemy.transform.Translate(direction * _rangeEnemy.speed * Time.fixedDeltaTime);
            }
        }
        else if (_rangeEnemy.distance < 5)
        {
            nextState = RangeEnemyStates.RangeAttackState;
        }

        if (!currentState.StateKey.Equals(nextState))
        {
            ChangeState(nextState);
        }
    }
}
