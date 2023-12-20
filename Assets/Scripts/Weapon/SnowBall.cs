using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public float snowBallSpeed;
    public float life;
    public float damage;

    private SnowBallShooter shooter;
    public void SetShooter(SnowBallShooter shooter)
    {
        this.shooter = shooter;
    }

    private void OnCollisionEnter(Collision collision)
    {
        BaseEnemy baseEnemy = collision.gameObject.GetComponent<BaseEnemy>();

        if (baseEnemy != null)
        {
            baseEnemy.TakeDamage(damage);
            shooter.ReturnToPool(this);
            //Debug.Log(collision.gameObject.name);
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
    }
}
