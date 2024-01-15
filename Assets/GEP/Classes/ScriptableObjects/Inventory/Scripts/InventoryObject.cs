using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory", menuName ="Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{

    public Inventory container;
    public void AddItem (Item _item, int _amount)
    {
        for (int i = 0; i < container.Items.Count; i++)
        {
            if (container.Items[i].item.ID == _item.ID)
            {
                container.Items[i].AddAmount(_amount);
                return;
            }
        }
            container.Items.Add(new InventorySlot(_item, _amount));
    }

    public void RemoveItem()
    {
        //if (container.Items.Count != 0)
        //{
        //    if(container.Items[container.Items.Count - 1].MinusAmount(1) == 0)
        //    {
        //        container.Items.RemoveAt(container.Items.Count - 1);
        //    }
        //}
    }


}

[System.Serializable]
public class Inventory
{
    public List<InventorySlot> Items = new List<InventorySlot>();

}


[System.Serializable]
public class InventorySlot
{
    public Item item;
    public int amount;
    public InventorySlot(Item _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
    //public int MinusAmount(int value)
    //{
    //    if (amount > 0)
    //    {
    //        amount -= value;
    //        //GameObject temp = GameObject.Instantiate(item);
    //        temp.transform.position = new Vector3(0, 0, 0);
    //        if (amount <= 0)
    //        {
    //            amount = 0;
    //            item = null;
    //            return 0;
    //        }
    //    }
    //    return 1;
    //}
}