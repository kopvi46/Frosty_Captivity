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

    public GameObject meleeEnemyPrefab;
    public int initialEnemyCount;
    public float spawnRadius;

    void Start()
    {
        for (int i = 0; i < initialEnemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        Vector3 randomSpawnPoint = Random.insideUnitSphere * spawnRadius;
        randomSpawnPoint.y = 0;

        Instantiate(meleeEnemyPrefab, randomSpawnPoint, Quaternion.identity);
    }
}
