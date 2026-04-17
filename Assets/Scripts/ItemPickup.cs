using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemScript Item;

    void Pickup()
    {
        Debug.Log("Picking up: " + Item);

        BagManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
       }
    }
}
