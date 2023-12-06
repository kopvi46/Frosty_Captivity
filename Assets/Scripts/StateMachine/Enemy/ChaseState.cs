using UnityEngine;

public class ChaseState : BaseState<MeleeEnemyStateManager.MeleeEnemyStates>
{
    public ChaseState(MeleeEnemyStateManager.MeleeEnemyStates key) : base(key) { }
    public override void Enter()
    {
        Debug.Log("Entered Chase State");
    }
    public override void Exit()
    {
        Debug.Log("Exited Chase State");
    }
    public override void Update()
    {

    }
}
