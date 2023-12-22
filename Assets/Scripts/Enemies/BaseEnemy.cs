using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    public Transform playerTarget;
    public Transform fireplaceTarget;
    public float speed;
    public float playerDistance;
    public float fireplaceDistance;
    public float maxHealth;
    public float health;
    public float heatDamage;
    public float heatDamageDelay;
    public float changePatrolDirectionInterval;
    public float maxPatrolDistance;
    public float patrolSpeedMultiplier;
    public float attackForce;

    private void Awake()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        GameObject fireplaceObject = GameObject.FindGameObjectWithTag("Fireplace");

        if (playerObject != null)
        {
            playerTarget = playerObject.transform;
        }

        if (fireplaceObject != null)
        {
            fireplaceTarget = fireplaceObject.transform;
        }
    }

    void FixedUpdate()
    {
        if (playerTarget != null)
        {
            playerDistance = Vector3.Distance(transform.position, playerTarget.position);
        }

        if (fireplaceTarget != null)
        {
            fireplaceDistance = Vector3.Distance(transform.position, fireplaceTarget.position);
        }

        if (fireplaceDistance <= 10)
        {
            heatDamageDelay += Time.deltaTime;

            if (heatDamageDelay >= 3)
            {
                health -= heatDamage;

                heatDamageDelay = 0f;
            }
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public abstract void TakeDamage(float damage);

    public abstract void Die();
}
