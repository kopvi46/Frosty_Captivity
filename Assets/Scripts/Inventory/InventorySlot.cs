using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Item item;

    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot ()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            Transform playerTransform = playerObject.transform;

            Vector3 spawnOffset = Vector3.forward * 1f;
            Vector3 spawnPosition = playerTransform.position + spawnOffset;

            DropItem(item.itemPrefab, spawnPosition);
        } else
        {
            Debug.LogError("Player GameObject not found or tagged incorrectly!");
        }

        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

    public void DropItem(GameObject prefab, Vector3 spawnPosition)
    {
        if (item != null)
        {
            GameObject newIt = Instantiate(item.itemPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
