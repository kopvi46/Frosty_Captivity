using UnityEngine;

public class MeleeChaseState : BaseState<MeleeEnemyStateManager.MeleeEnemyStates>
{
    public MeleeChaseState(MeleeEnemyStateManager.MeleeEnemyStates key) : base(key) { }
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
