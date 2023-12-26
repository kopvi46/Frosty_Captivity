using UnityEngine;

public class SnowBallShooter : MonoBehaviour
{
    public Transform snowBallSpawnPoint;
    public float damage;

    private const int SNOWBALL_PRELOAD_COUNT = 10;
    private PoolBase<SnowBall> _snowBallPool;
    [SerializeField] private Initializer _initializer;
    [SerializeField] private SnowBall _snowball;
    [SerializeField] private SnowBall _snowballPrefab;

    private void Awake()
    {
        _initializer.shootEvent.AddListener(OnShoot);
        _snowball.damage = damage;
        _snowBallPool = new PoolBase<SnowBall>(Preload, GetAction, ReturnAction, SNOWBALL_PRELOAD_COUNT);
    }

    private void OnShoot()
    {
        SnowBall snowBall = _snowBallPool.Get();

        snowBall.transform.position = snowBallSpawnPoint.position;
        snowBall.transform.rotation = snowBallSpawnPoint.rotation;
        snowBall.GetComponent<Rigidbody>().velocity = snowBallSpawnPoint.forward * _snowball.snowBallSpeed;

        snowBall.SetShooter(this);
    }

    public void ReturnToPool(SnowBall snowBall)
    {
        _snowBallPool.Return(snowBall);
    }

    public SnowBall Preload() => Instantiate(_snowballPrefab);
    public void GetAction(SnowBall snowBall) => snowBall.gameObject.SetActive(true);
    public void ReturnAction(SnowBall snowBall) => snowBall.gameObject.SetActive(false);
}

