using UnityEngine;

public class MeleeChaseState : BaseState<MeleeEnemyStateManager.MeleeEnemyStates>
{
    private MeleeEnemy _meleeEnemy;

    public MeleeChaseState(MeleeEnemyStateManager.MeleeEnemyStates key, MeleeEnemy meleeEnemy) : base(key)
    {
        _meleeEnemy = meleeEnemy;
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
        _meleeEnemy.transform.LookAt(_meleeEnemy.playerTarget.position);
        _meleeEnemy.transform.Translate(Vector3.forward * _meleeEnemy.speed * Time.deltaTime);
    }
}
