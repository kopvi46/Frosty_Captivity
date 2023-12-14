using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public GameObject itemPrefab;

    public virtual void Use ()
    {
        Debug.Log("Using " + name);
        if (name  == "Firewood" && FireplaceMainCore.instance.distance < 5)
        {
            FireplaceMainCore.instance.fireplaceHealth += 100;

            if (FireplaceMainCore.instance.fireplaceHealth > 1000)
            {
                FireplaceMainCore.instance.fireplaceHealth = 1000;
            }
            Inventory.instance.Remove(this);
        }
    }
}
