using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
    #region Singleton 
    public static MeleeEnemy instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of FireplaceMainCore found!");
        }
        instance = this;
    }
    #endregion

    public float changePatrolDirectionInterval;
    public float maxPatrolDistance;
    public float patrolSpeedMultiplier;
    public float attackForce;

    private void Start()
    {
        health = maxHealth;
        _bars.SetMaxMeleeEnemyHealth(maxHealth);
    }

    private void Update()
    {
        if (fireplaceDistance <= 10)
        {
            heatDamageDelay += Time.deltaTime;

            if (heatDamageDelay >= 3)
            {
                health -= heatDamage;
                _bars.SetMeleeEnemyHealth(health);

                heatDamageDelay = 0f;
            }
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public override void TakeDamage(float amount)
    {
        health -= amount;
        _bars.SetMeleeEnemyHealth(health);
    }
}
