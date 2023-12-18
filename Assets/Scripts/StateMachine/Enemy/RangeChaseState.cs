using UnityEngine;

public class RangeChaseState : BaseState<RangeEnemyStateManager.RangeEnemyStates>
{
    public RangeChaseState(RangeEnemyStateManager.RangeEnemyStates key) : base(key) { }
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
