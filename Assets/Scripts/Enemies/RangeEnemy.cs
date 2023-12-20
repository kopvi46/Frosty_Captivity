using UnityEngine;

public class RangeEnemy : BaseEnemy
{
    private void Start()
    {
        health = maxHealth;
        Bars.instance.SetMaxRangeEnemyHealth(maxHealth);
    }

    private void Update()
    {
        Bars.instance.SetRangeEnemyHealth(health);
    }

    public override void TakeDamage(float amount)
    {
        health -= amount;
    }
}
