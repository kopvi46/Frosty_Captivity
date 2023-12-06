using UnityEngine;

public class MeleeAttackState : BaseState<MeleeEnemyStateManager.MeleeEnemyStates>
{
    public MeleeAttackState(MeleeEnemyStateManager.MeleeEnemyStates key) : base(key) { }
    public override void Enter()
    {
        Debug.Log("Entered melee Attack State");
    }
    public override void Exit()
    {
        Debug.Log("Exited melee Attack State");
    }
    public override void Update()
    {

    }
}
