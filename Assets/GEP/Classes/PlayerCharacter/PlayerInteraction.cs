using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public InventoryObject inventory;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if(item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    public void OnDropItem()
    {
        if (inventory.container.Count > 0)
        {
            GameObject temp;
            temp = Instantiate(inventory.container[inventory.container.Count - 1].item.itemPrefab, Vector3.zero, Quaternion.identity, transform);
            temp.transform.SetParent(null);
            inventory.RemoveItem();
        }

    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }


    void OnCollisionEnter(Collision collision)
    {
        IPickupable pickupable = collision.gameObject.GetComponent<IPickupable>();
        if (pickupable != null)
        {
            pickupable.Pickup();
        }
    }
}
