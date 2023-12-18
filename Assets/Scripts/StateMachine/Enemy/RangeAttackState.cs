using UnityEngine;

public class RangeAttackState : BaseState<RangeEnemyStateManager.RangeEnemyStates>
{
    public RangeAttackState(RangeEnemyStateManager.RangeEnemyStates key) : base(key) { }
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
