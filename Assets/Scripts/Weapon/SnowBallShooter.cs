using UnityEngine;

public class SnowBallShooter : MonoBehaviour
{
    public Transform snowBallSpawnPoint;
    public float damage;
    public float range;

    [SerializeField] private Initializer _initializer;
    [SerializeField] private SnowBall _snowBall;
    public SnowBallShooter _snowBallShooter;

    private void Awake()
    {
        _initializer.shootEvent.AddListener(OnShoot);
        _snowBall.damage = damage;
    }

    private void OnShoot()
    {
        GameObject snowBall = Instantiate(_snowBall.snowBallPrefab, snowBallSpawnPoint.position, snowBallSpawnPoint.rotation);
        snowBall.GetComponent<Rigidbody>().velocity = snowBallSpawnPoint.forward * _snowBall.snowBallSpeed;
    }
}
