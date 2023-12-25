using UnityEngine;

public class RangeAttackState : BaseState<RangeEnemyStateManager.RangeEnemyStates>
{
    private RangeEnemy _rangeEnemy;
    private EnemyShooter _enemyShooter;
    private float timer = 0;

    public RangeAttackState(RangeEnemyStateManager.RangeEnemyStates key, RangeEnemy rangeEnemy, EnemyShooter enemyShooter) : base(key)
    {
        _rangeEnemy = rangeEnemy;
        _enemyShooter = enemyShooter;
    }

    public override void Enter() { }

    public override void Exit() { }

    public override void Update()
    {
        _rangeEnemy.transform.LookAt(_rangeEnemy.playerTarget.position);

        timer += Time.deltaTime;

        if (timer >= 1)
        {
            _enemyShooter.Shoot();
            timer = 0f;
        }
    }
}
