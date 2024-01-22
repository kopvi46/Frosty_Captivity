using UnityEngine;

public class MeleeAttackState : BaseState<MeleeEnemyStateManager.MeleeEnemyStates>
{
    private MeleeEnemy _meleeEnemy;
    private float timer = 1.9f;

    public MeleeAttackState(MeleeEnemyStateManager.MeleeEnemyStates key, MeleeEnemy meleeEnemy) : base(key)
    {
        _meleeEnemy = meleeEnemy;
    }

    public override void Enter() { }

    public override void Exit() { }

    public override void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2)
        {
            PlayerMainCore.instance.playerHealth -= _meleeEnemy.attackForce;

            timer = 0f;
        }
    }
}
