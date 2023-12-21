using UnityEngine;
using UnityEngine.UIElements;

public class MeleePatrolState : BaseState<MeleeEnemyStateManager.MeleeEnemyStates>
{
    private MeleeEnemy _meleeEnemy;

    public MeleePatrolState(MeleeEnemyStateManager.MeleeEnemyStates key, MeleeEnemy meleeEnemy) : base(key)
    {
        _meleeEnemy = meleeEnemy;
    }

    private Vector3 randomPoint;
    private float timer;

    public override void Enter()
    {
        Debug.Log("Entered Patrol State");

        SetRandomDestination();
    }
    public override void Exit()
    {
        //Debug.Log("Exited Patrol State");

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
