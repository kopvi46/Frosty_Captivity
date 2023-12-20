using UnityEngine;

public class MeleeAttackState : BaseState<MeleeEnemyStateManager.MeleeEnemyStates>
{
    public MeleeAttackState(MeleeEnemyStateManager.MeleeEnemyStates key) : base(key) { }

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

            PlayerMainCore.instance.playerHealth -= MeleeEnemy.instance.attackForce;

            timer = 0f;
        }
    }
}
