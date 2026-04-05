using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BagManager : MonoBehaviour
{
    public static BagManager Instance;

    [SerializeField, HideInInspector]
    private List<ItemScript> items = new List<ItemScript>();

    public IReadOnlyList<ItemScript> Items => items;

    public Transform ItemContent;
    public GameObject InventoryItem;

    //public Toggle EnableRemove;

    public InventoryItemController[] InventoryItems;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void Add(ItemScript item)
    {
        items.Add(item);

        ListItem();
    }

    public void Remove(ItemScript item)
    {
        items.Remove(item);

        ListItem();
    }

    public void ListItem()
    {
        if (ItemContent == null || InventoryItem == null)
        {
            Debug.LogError("Missing references!");
            return;
        }

        // Clear old UI
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        // Build UI once
        foreach (var item in Items)
        {
            if (item == null) continue;

            GameObject obj = Instantiate(InventoryItem, ItemContent);

            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            //var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();
            //var controller = obj.GetComponent<InventoryItemController>();

            if (itemName != null)
                itemName.text = item.itemName;

            if (itemIcon != null)
                itemIcon.sprite = item.icon;

            //if (controller != null)
                //controller.AddItem(item);

            //if (removeButton != null && controller != null)
            //{
                //removeButton.gameObject.SetActive(EnableRemove.isOn);
                //removeButton.onClick.RemoveAllListeners();
                //removeButton.onClick.AddListener(controller.RemoveItem);
            //}
        }

        //SetInventoryItems();
    }

    //public void EnableItemsRemove()
    //{
        //if (EnableRemove.isOn)
        //{
            //foreach (Transform item in ItemContent)
            //{
                //item.Find("RemoveButton").gameObject.SetActive(true);
            //}
        //}
        //else
        //{
            //foreach (Transform item in ItemContent)
            //{
                //item.Find("RemoveButton").gameObject.SetActive(false);
            //}
        //}
    //}

    //public void SetInventoryItems()
    //{
        //InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        //for (int i = 0; i <Items.Count; i++)
        //{
            //InventoryItems[i].AddItem(Items[i]);
        //}
    //}
}