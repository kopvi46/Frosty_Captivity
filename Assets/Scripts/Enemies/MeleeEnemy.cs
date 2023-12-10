using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
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
