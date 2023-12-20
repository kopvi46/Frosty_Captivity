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

        UpdateCurrentState();

        if (_meleeEnemy.playerDistance > 20)
        {
            nextState = MeleeEnemyStates.MeleePatrolState;
        }
        else if (_meleeEnemy.playerDistance < 20 && _meleeEnemy.playerDistance > 2)
        {
            nextState = MeleeEnemyStates.MeleeChaseState;
        }
        else if (_meleeEnemy.playerDistance < 2)
        {
            nextState = MeleeEnemyStates.MeleeAttackState;
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
