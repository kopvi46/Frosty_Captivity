using UnityEngine;

public class RangePatrolState : BaseState<RangeEnemyStateManager.RangeEnemyStates>
{
    private RangeEnemy _rangeEnemy;

    public RangePatrolState(RangeEnemyStateManager.RangeEnemyStates key, RangeEnemy rangeEnemy) : base(key)
    {
        _rangeEnemy = rangeEnemy;
    }

    private Vector3 randomPoint;
    private float timer;

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

        if (timer >= _rangeEnemy.changePatrolDirectionInterval)
        {
            SetRandomDestination();
            timer = 0f;
        }

        MoveToRandomPoint();
    }

    void SetRandomDestination()
    {
        randomPoint = _rangeEnemy.transform.position + Random.insideUnitSphere * _rangeEnemy.maxPatrolDistance;
        randomPoint.y = _rangeEnemy.transform.position.y;
    }

    void MoveToRandomPoint()
    {
        _rangeEnemy.transform.LookAt(randomPoint);
        _rangeEnemy.transform.Translate(Vector3.forward * _rangeEnemy.speed * Time.deltaTime);
    }
}
