using UnityEngine;
using UnityEngine.UIElements;

public class MeleePatrolState : BaseState<MeleeEnemyStateManager.MeleeEnemyStates>
{
    public MeleePatrolState(MeleeEnemyStateManager.MeleeEnemyStates key) : base(key) { }

    private Vector3 randomPoint;
    private float timer;

    public override void Enter()
    {
        Debug.Log("Entered Patrol State");
        //SetRandomDestination();
    }
    public override void Exit()
    {
        Debug.Log("Exited Patrol State");
        randomPoint = Vector3.zero;
    }
    public override void Update()
    {
        timer += Time.deltaTime;

        if (timer >= MeleeEnemy.instance.changePatrolDirectionInterval)
        {
            SetRandomDestination();
            timer = 0f;
        }

        MoveToRandomPoint();
    }

    void SetRandomDestination()
    {
        randomPoint = MeleeEnemy.instance.transform.position + Random.insideUnitSphere * MeleeEnemy.instance.maxPatrolDistance;
        randomPoint.y = MeleeEnemy.instance.transform.position.y;
    }

    void MoveToRandomPoint()
    {
        MeleeEnemy.instance.transform.LookAt(randomPoint);
        MeleeEnemy.instance.transform.Translate(Vector3.forward * MeleeEnemy.instance.speed * MeleeEnemy.instance.patrolSpeedMultiplier * Time.deltaTime);
    }
}
