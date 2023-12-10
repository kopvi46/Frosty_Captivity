using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float distance;
    public float enemyMaxHealth;
    public float enemyHealth;

    [SerializeField] private Bars _bars;
    private void Start()
    {
        enemyHealth = enemyMaxHealth;
    }
    void FixedUpdate()
    {
        if (target != null)
        {
            distance = Vector3.Distance(transform.position, target.position);
        }
    }

    public abstract void TakeDamage(float damage);

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
