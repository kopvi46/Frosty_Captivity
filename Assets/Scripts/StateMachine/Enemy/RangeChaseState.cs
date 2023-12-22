using UnityEngine;

public class RangeChaseState : BaseState<RangeEnemyStateManager.RangeEnemyStates>
{
    private RangeEnemy _rangeEnemy;

    public RangeChaseState(RangeEnemyStateManager.RangeEnemyStates key, RangeEnemy rangeEnemy) : base(key)
    {
        _rangeEnemy = rangeEnemy;
    }

    public override void Enter()
    {
        //Debug.Log("Entered Chase State");
    }
    public override void Exit()
    {
        //Debug.Log("Exited Chase State");
    }
    public override void Update()
    {
        _rangeEnemy.transform.LookAt(_rangeEnemy.playerTarget.position);
        _rangeEnemy.transform.Translate(Vector3.forward * _rangeEnemy.speed * Time.deltaTime);
    }
}
