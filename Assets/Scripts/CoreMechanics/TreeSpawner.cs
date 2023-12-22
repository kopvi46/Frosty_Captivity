using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public TreeMainCore treeMainCore;
    public Transform playerTarget;
    public Transform fireplaceTarget;
    public GameObject treePrefab;
    public int initialTreeCount;
    public float spawnRadius;
    public float spawnDistance;

    void Start()
    {
        for (int i = 0; i < initialTreeCount; i++)
        {
            SpawnTree();
        }
    }

    public void SpawnTree()
    {
        Vector3 randomSpawnPoint = Vector3.zero;
        float sqrSpawnDistance = spawnDistance * spawnDistance;

        do
        {
            randomSpawnPoint = Random.insideUnitSphere * spawnRadius;
            randomSpawnPoint.y = 1.5f;
        } while (CheckPlayerDistance(randomSpawnPoint, playerTarget.position, sqrSpawnDistance) && CheckFireplaceDistance(randomSpawnPoint, fireplaceTarget.position, sqrSpawnDistance));

        GameObject newTree = Instantiate(treePrefab, randomSpawnPoint, Quaternion.identity);

        newTree.GetComponent<TreeMainCore>().SetFirewood(treeMainCore.firewoodPrefab);
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