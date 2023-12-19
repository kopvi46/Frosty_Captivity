using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float changeInterval = 3f;
    public float maxDistance = 5f;

    private Vector3 randomPoint;
    private float timer;

    void Start()
    {
        SetRandomDestination();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= changeInterval)
        {
            SetRandomDestination();
            timer = 0f;
        }

        MoveToRandomPoint();
    }

    void SetRandomDestination()
    {
        randomPoint = transform.position + Random.insideUnitSphere * maxDistance;
        randomPoint.y = transform.position.y;
    }

    void MoveToRandomPoint()
    {
        transform.LookAt(randomPoint);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
