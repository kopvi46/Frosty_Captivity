using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public GameObject snowBallPrefab;
    public float snowBallSpeed;
    public float life;
    public float damage;

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        Target target = collision.gameObject.GetComponent<Target>();

        if (target != null)
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
            Debug.Log(target.name);
        }
    }
}
