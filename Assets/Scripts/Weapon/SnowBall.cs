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
        Target target = collision.gameObject.GetComponent<Target>();

        if (target != null)
        {
            target.TakeDamage(damage);
            shooter.ReturnToPool(this);
            Debug.Log(collision.gameObject.name);
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
