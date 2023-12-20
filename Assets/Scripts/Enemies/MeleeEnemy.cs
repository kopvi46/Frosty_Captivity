using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
    #region Singleton 
    public static MeleeEnemy instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of MeleeEnemy found!");
        }
        instance = this;
    }
    #endregion

    private void Start()
    {
        health = maxHealth;
        Bars.instance.SetMaxMeleeEnemyHealth(maxHealth);
    }

    private void Update()
    {
        Bars.instance.SetMeleeEnemyHealth(health);
    }

    public override void TakeDamage(float amount)
    {
        health -= amount;
    }
}
