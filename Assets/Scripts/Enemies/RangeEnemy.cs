using UnityEngine;

public class RangeEnemy : BaseEnemy
{
    private void Start()
    {
        health = maxHealth;
        _bars.SetMaxRangeEnemyHealth(maxHealth);
    }

    public override void TakeDamage(float amount)
    {
        health -= amount;
        _bars.SetRangeEnemyHealth(health);
        if (health <= 0)
        {
            Die();
        }
    }
}
