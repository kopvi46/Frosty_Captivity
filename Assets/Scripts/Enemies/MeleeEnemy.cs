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

    private void Start()
    {
        health = maxHealth;
        _bars.SetMaxMeleeEnemyHealth(maxHealth);
    }

    public override void TakeDamage(float amount)
    {
        health -= amount;
        _bars.SetMeleeEnemyHealth(health);
        if (health <= 0)
        {
            Die();
        }
    }
}
