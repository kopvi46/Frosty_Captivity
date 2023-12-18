using UnityEngine;

public class MeleeEnemyStateManager : StateManager<MeleeEnemyStateManager.MeleeEnemyStates>
{
    public MeleeEnemy _meleeEnemy;

    public enum MeleeEnemyStates
    {
        MeleePatrolState,
        MeleeChaseState,
        MeleeAttackState
    }
    void Awake()
    {
        States.Add(MeleeEnemyStates.MeleePatrolState, new MeleePatrolState(MeleeEnemyStates.MeleePatrolState));
        States.Add(MeleeEnemyStates.MeleeChaseState, new MeleeChaseState(MeleeEnemyStates.MeleeChaseState));
        States.Add(MeleeEnemyStates.MeleeAttackState, new MeleeAttackState(MeleeEnemyStates.MeleeAttackState));

        currentState = States[MeleeEnemyStates.MeleePatrolState];
    }

    void Update()
    {
        MeleeEnemyStates nextState = currentState.StateKey;

        if (_meleeEnemy.distance > 20)
        {
            nextState = MeleeEnemyStates.MeleePatrolState;
        } 
        else if (_meleeEnemy.distance < 20 && _meleeEnemy.distance > 5)
        {
            nextState = MeleeEnemyStates.MeleeChaseState;

            if (_meleeEnemy != null && _meleeEnemy.target != null)
            {
                Vector3 direction = _meleeEnemy.target.position - _meleeEnemy.transform.position;
                direction.Normalize();
                _meleeEnemy.transform.Translate(direction * _meleeEnemy.speed * Time.fixedDeltaTime);
            }
        }
        else if (_meleeEnemy.distance < 5)
        {
            nextState = MeleeEnemyStates.MeleeAttackState;
        }

        if(!currentState.StateKey.Equals(nextState))
        {
            ChangeState(nextState);
        }
    }
}
