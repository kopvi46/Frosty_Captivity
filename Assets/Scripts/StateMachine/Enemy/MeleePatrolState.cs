using UnityEngine;
using UnityEngine.UIElements;

public class MeleePatrolState : BaseState<MeleeEnemyStateManager.MeleeEnemyStates>
{
    public MeleePatrolState(MeleeEnemyStateManager.MeleeEnemyStates key) : base(key) { }

    public override void Enter()
    {
        Debug.Log("Entered Patrol State");
    }
    public override void Exit()
    {
        Debug.Log("Exited Patrol State");
    }
    public override void Update()
    {

    }
}
