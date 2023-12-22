using UnityEngine;
using static UnityEditor.Progress;

public class TreeMainCore : Interactable
{
    public float hitToGather;

    public GameObject firewoodPrefab;
    private GameObject createdFirewood;

    public void SetFirewood(GameObject prefab)
    {
        firewoodPrefab = prefab;
    }

    public override void Interact()
    {
        base.Interact();

        //if ( hitToGather <= 1 )
        //{
        //    GameObject treeObject = GameObject.FindGameObjectWithTag("Tree");
        //    if (treeObject != null)
        //    {
        //        Transform playerTransform = treeObject.transform;

        //        Vector3 spawnOffset = Vector3.up * -1.5f;
        //        Vector3 spawnPosition = playerTransform.position + spawnOffset;

        //        CreateItem(firewoodPrefab, spawnPosition);
        //        Destroy(gameObject);
        //    } else
        //    {
        //        Debug.LogError("Tree GameObject not found or tagged incorrectly!");
        //    }
        //} else
        //{
        //    Obtain();
        //}

        if (hitToGather <= 1)
        {
            if (createdFirewood != null)
            {
                Destroy(createdFirewood);
            }

            Vector3 spawnOffset = Vector3.up * -1.5f;
            createdFirewood = Instantiate(firewoodPrefab, transform.position + spawnOffset, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Obtain();
        }
    }

    void Obtain()
    {
        hitToGather -= 1;
    }

    public void CreateItem(GameObject prefab, Vector3 spawnPosition)
    {
        if (firewoodPrefab != null)
        {
            GameObject newIt = Instantiate(firewoodPrefab, spawnPosition, Quaternion.identity);
        }
    }
}