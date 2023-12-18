using UnityEngine;

public class RangePatrolState : BaseState<RangeEnemyStateManager.RangeEnemyStates>
{
    public RangePatrolState(RangeEnemyStateManager.RangeEnemyStates key) : base(key) { }
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
