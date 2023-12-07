using UnityEngine;

public class MeleeEnemyStateManager : StateManager<MeleeEnemyStateManager.MeleeEnemyStates>
{
    public MeleeEnemy _meleeEnemy;

    public enum MeleeEnemyStates
    {
        PatrolState,
        ChaseState,
        MeleeAttackState
    }
    void Awake()
    {
        States.Add(MeleeEnemyStates.PatrolState, new PatrolState(MeleeEnemyStates.PatrolState));
        States.Add(MeleeEnemyStates.ChaseState, new ChaseState(MeleeEnemyStates.ChaseState));
        States.Add(MeleeEnemyStates.MeleeAttackState, new MeleeAttackState(MeleeEnemyStates.MeleeAttackState));

        currentState = States[MeleeEnemyStates.PatrolState];
    }

    void Update()
    {
        MeleeEnemyStates nextState = currentState.StateKey;

        if (_meleeEnemy.distance > 20)
        {
            nextState = MeleeEnemyStates.PatrolState;
        } 
        else if (_meleeEnemy.distance < 20 && _meleeEnemy.distance > 5)
        {
            nextState = MeleeEnemyStates.ChaseState;

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