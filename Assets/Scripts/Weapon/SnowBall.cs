using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public float snowBallSpeed;
    public float life;
    public float damage;

    private SnowBallShooter shooter;
    private EnemyShooter enemyShooter;

    public void SetShooter(SnowBallShooter shooter)
    {
        this.shooter = shooter;
    }

    public void SetEnemyShooter(EnemyShooter enemyShooter)
    {
        this.enemyShooter = enemyShooter;
    }

    private void OnCollisionEnter(Collision collision)
    {
        BaseEnemy baseEnemy = collision.gameObject.GetComponent<BaseEnemy>();
        PlayerMainCore playerMainCore = collision.gameObject.GetComponent<PlayerMainCore>();

        if (baseEnemy != null)
        {
            if (shooter != null)
            {
                baseEnemy.TakeDamage(damage);
                shooter.ReturnToPool(this);
            }
        }

        if (playerMainCore != null)
        {
            if (enemyShooter != null)
            {
                playerMainCore.playerHealth -= damage;
                enemyShooter.ReturnToPool(this);
            }
        }
    }

    private void OnEnable()
    {
        Invoke(nameof(CheckCollision), 3f);
    }

    private void CheckCollision()
    {
        if (shooter != null)
        {
            shooter.ReturnToPool(this);
        }

        if (enemyShooter != null)
        {
            enemyShooter.ReturnToPool(this);
        }
    }
}
