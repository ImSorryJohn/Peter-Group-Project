using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    public ItemScript item;

    public Button RemoveButton;
    
    public void RemoveItem()
    {
        if (item == null)
        {
            Debug.LogError("Item is NULL!");
            return;
        }

        BagManager.Instance.Remove(item);

        Destroy(gameObject);
    }

    public void AddItem(ItemScript newItem)
    {
        item = newItem;
    }
}
