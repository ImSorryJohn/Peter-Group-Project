using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    public ItemScript item;

    //public Button RemoveButton;
    
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

    public void UseItem()
    {
        if (item == null) return;

        switch (item.itemType)
        {
            case ItemScript.ItemType.Potion:
            PlayerStats.Instance.IncreaseHealth(item.value);
                break;
            case ItemScript.ItemType.ExpPotion:
            PlayerStats.Instance.IncreaseExp(item.value);
                break;
        }

        RemoveItem();
    }
}
