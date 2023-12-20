using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] protected Bars _bars;

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
    }

    public abstract void TakeDamage(float damage);

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
