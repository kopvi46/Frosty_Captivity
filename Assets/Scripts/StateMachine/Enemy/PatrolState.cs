using UnityEngine;

public class PatrolState : BaseState<MeleeEnemyStateManager.MeleeEnemyStates>
{
    public PatrolState(MeleeEnemyStateManager.MeleeEnemyStates key) : base(key) { }
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
