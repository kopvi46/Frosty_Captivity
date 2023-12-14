using UnityEngine;
using static UnityEditor.Progress;

public class TreeMainCore : Interactable
{
    public float hitToGather;

    public GameObject itemPrefab;

    public override void Interact()
    {
        base.Interact();

        if ( hitToGather <= 1 )
        {
            GameObject treeObject = GameObject.FindGameObjectWithTag("Tree");
            if (treeObject != null)
            {
                Transform playerTransform = treeObject.transform;

                Vector3 spawnOffset = Vector3.up * -1.5f;
                Vector3 spawnPosition = playerTransform.position + spawnOffset;

                CreateItem(itemPrefab, spawnPosition);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("Tree GameObject not found or tagged incorrectly!");
            }
        } else
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
        if (itemPrefab != null)
        {
            GameObject newIt = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
