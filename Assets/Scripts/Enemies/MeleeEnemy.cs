using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
    #region Singleton 
    //public static MeleeEnemy instance;

    //private void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Debug.Log("More than one instance of MeleeEnemy found!");
    //    }
    //    instance = this;
    //}
    #endregion

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
