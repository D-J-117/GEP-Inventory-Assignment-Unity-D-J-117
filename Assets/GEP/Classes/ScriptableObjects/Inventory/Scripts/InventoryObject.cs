using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory", menuName ="Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> container = new List<InventorySlot>();
    //public var inventoryDisplay;

    public void AddItem (ItemObject _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == _item)
            {
                container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            container.Add(new InventorySlot(_item, _amount));
               
        }

        
    }

    public void RemoveItem()
    {
        if (container.Count > 0)
        {
            container[container.Count-1].AddAmount(-1);
            //if (container[index].amount <= 0)
            //{
            //    inventoryDisplay.GetComponentInChildren<DisplayInventory>().RemoveItem(container[index]);
            //    container.RemoveAt(index);
            //}
            
        }
    }

    public void DeleteEmptyItems()
    {
        container.RemoveAt(container.Count - 1);
        //for (int i = 0; i < container.Count; i++)
        //{
        //    if (container[i].amount <= 0)
        //    {
        //        container.RemoveAt(i);
        //    }
        //}
    }

}


[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public void MinusAmount(int value)
    {
        amount -= value;
        if (amount <= 0)
        {

        }
    }
}

