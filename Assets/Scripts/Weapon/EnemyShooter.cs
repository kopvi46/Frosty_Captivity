using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    private const int SNOWBALL_PRELOAD_COUNT = 10;
    public Transform snowBallSpawnPoint;
    public float damage;

    [SerializeField] private SnowBall _snowball;
    [SerializeField] private SnowBall _snowballPrefab;

    private PoolBase<SnowBall> _snowBallPool;

    private void Awake()
    {
        _snowball.damage = damage;
        _snowBallPool = new PoolBase<SnowBall>(Preload, GetAction, ReturnAction, SNOWBALL_PRELOAD_COUNT);
    }

    public void Shoot()
    {
        SnowBall snowBall = _snowBallPool.Get();

        snowBall.transform.position = snowBallSpawnPoint.position;
        snowBall.transform.rotation = snowBallSpawnPoint.rotation;
        snowBall.GetComponent<Rigidbody>().velocity = snowBallSpawnPoint.forward * _snowball.snowBallSpeed;

        snowBall.SetEnemyShooter(this);
    }

    public void ReturnToPool(SnowBall snowBall)
    {
        _snowBallPool.Return(snowBall);
    }

    public SnowBall Preload() => Instantiate(_snowballPrefab);
    public void GetAction(SnowBall snowBall) => snowBall.gameObject.SetActive(true);
    public void ReturnAction(SnowBall snowBall) => snowBall.gameObject.SetActive(false);
}
