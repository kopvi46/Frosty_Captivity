using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
    [SerializeField] MeleeEnemyBar meleeEnemyBar;

    private void Start()
    {
        health = maxHealth;
        meleeEnemyBar.SetMaxMeleeEnemyHealth(maxHealth);
    }

    private void Update()
    {
        meleeEnemyBar.SetMeleeEnemyHealth(health);
    }

    public override void TakeDamage(float amount)
    {
        health -= amount;
    }

    public override void Die()
    {
        Destroy(gameObject);
        EnemiesSpawner.instance.SpawnEnemy(EnemiesSpawner.instance.meleeEnemyPrefab);
    }
}
