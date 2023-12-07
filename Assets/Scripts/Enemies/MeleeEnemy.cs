using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float distance;

    void FixedUpdate()
    {
        if ( target != null )
        {
            distance = Vector3.Distance(transform.position, target.position);
        }
    }
}
