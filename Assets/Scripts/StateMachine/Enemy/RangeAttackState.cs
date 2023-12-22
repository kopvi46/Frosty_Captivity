using UnityEngine;

public class RangeAttackState : BaseState<RangeEnemyStateManager.RangeEnemyStates>
{
    private RangeEnemy _rangeEnemy;
    private EnemyShooter _enemyShooter;

    public RangeAttackState(RangeEnemyStateManager.RangeEnemyStates key, RangeEnemy rangeEnemy, EnemyShooter enemyShooter) : base(key)
    {
        _rangeEnemy = rangeEnemy;
        _enemyShooter = enemyShooter;
    }

    private float timer = 2;

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
        _rangeEnemy.transform.LookAt(_rangeEnemy.playerTarget.position);

        timer += Time.deltaTime;

        if (timer >= 1)
        {
            //Debug.Log("Attacking");

            //PlayerMainCore.instance.playerHealth -= _rangeEnemy.attackForce;
            _enemyShooter.Shoot();
            timer = 0f;
        }
    }
}
