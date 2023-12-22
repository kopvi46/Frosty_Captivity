using UnityEngine;

public class MeleeAttackState : BaseState<MeleeEnemyStateManager.MeleeEnemyStates>
{
    private MeleeEnemy _meleeEnemy;

    public MeleeAttackState(MeleeEnemyStateManager.MeleeEnemyStates key, MeleeEnemy meleeEnemy) : base(key)
    {
        _meleeEnemy = meleeEnemy;
    }

    private float timer = 3;

    public override void Enter()
    {
        //Debug.Log("Entered melee Attack State");
    }
    public override void Exit()
    {
        //Debug.Log("Exited melee Attack State");
    }
    public override void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2)
        {
            //Debug.Log("Attacking");

            PlayerMainCore.instance.playerHealth -= _meleeEnemy.attackForce;

            timer = 0f;
        }
    }
}
