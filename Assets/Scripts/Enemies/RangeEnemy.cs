using UnityEngine;

public class RangeEnemy : BaseEnemy
{
    [SerializeField] RangeEnemyBar rangeEnemyBar;


    private void Start()
    {
        health = maxHealth;
        rangeEnemyBar.SetMaxRangeEnemyHealth(maxHealth);
    }

    private void Update()
    {
        rangeEnemyBar.SetRangeEnemyHealth(health);
    }

    public override void TakeDamage(float amount)
    {
        health -= amount;
    }

    public override void Die()
    {
        Destroy(gameObject);
        EnemiesSpawner.instance.SpawnEnemy(EnemiesSpawner.instance.rangeEnemyPrefab);
    }
}
