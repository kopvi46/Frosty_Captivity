using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    #region Singleton
    public static EnemiesSpawner instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of EnemiesSpawner found!");
        }
        instance = this;
    }
    #endregion

    public Transform playerTarget;
    public Transform fireplaceTarget;
    public GameObject meleeEnemyPrefab;
    public GameObject rangeEnemyPrefab;
    public int initialEnemyCount;
    public float spawnRadius;
    public float spawnDistance;

    void Start()
    {
        for (int i = 0; i < initialEnemyCount; i++)
        {
            SpawnEnemy(meleeEnemyPrefab);
            SpawnEnemy(rangeEnemyPrefab);
        }
    }

    public void SpawnEnemy(GameObject enemyPrefab)
    {
        Vector3 randomSpawnPoint = Vector3.zero;
        float sqrSpawnDistance = spawnDistance * spawnDistance;

        do
        {
            randomSpawnPoint = Random.insideUnitSphere * spawnRadius;
            randomSpawnPoint.y = 0;
        } while (CheckPlayerDistance(randomSpawnPoint, playerTarget.position, sqrSpawnDistance) && CheckFireplaceDistance(randomSpawnPoint, fireplaceTarget.position, sqrSpawnDistance));

        Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.identity);
    }

    bool CheckPlayerDistance(Vector3 spawnPoint, Vector3 targetPosition, float sqrDistance)
    {
        return (spawnPoint - targetPosition).sqrMagnitude <= sqrDistance;
    }

    bool CheckFireplaceDistance(Vector3 spawnPoint, Vector3 targetPosition, float sqrDistance)
    {
        return (spawnPoint - targetPosition).sqrMagnitude <= sqrDistance;
    }
}
