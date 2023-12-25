using UnityEngine;

public class MeleePatrolState : BaseState<MeleeEnemyStateManager.MeleeEnemyStates>
{
    private MeleeEnemy _meleeEnemy;
    private Vector3 randomPoint;
    private float timer;

    public MeleePatrolState(MeleeEnemyStateManager.MeleeEnemyStates key, MeleeEnemy meleeEnemy) : base(key)
    {
        _meleeEnemy = meleeEnemy;
    }

    public override void Enter()
    {
        SetRandomDestination();
    }
    public override void Exit()
    {
        randomPoint = Vector3.zero;
        timer = 0f;
    }
    public override void Update()
    {
        timer += Time.deltaTime;

        if (timer >= _meleeEnemy.changePatrolDirectionInterval)
        {
            SetRandomDestination();
            timer = 0f;
        }

        MoveToRandomPoint();
    }

    void SetRandomDestination()
    {
        randomPoint = _meleeEnemy.transform.position + Random.insideUnitSphere * _meleeEnemy.maxPatrolDistance;
        randomPoint.y = _meleeEnemy.transform.position.y;
    }

    void MoveToRandomPoint()
    {
        _meleeEnemy.transform.LookAt(randomPoint);
        _meleeEnemy.transform.Translate(Vector3.forward * _meleeEnemy.speed * Time.deltaTime);
    }
}
