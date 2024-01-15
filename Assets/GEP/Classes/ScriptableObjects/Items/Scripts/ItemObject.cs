using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An enum storing different item types that can be extended
// depending on the type of game it is used in
public enum ItemType
{
    Default,
    Block

}

// Base class
public abstract class ItemObject : ScriptableObject
{
    public int ID;
    public Sprite uiDisplay;
    public ItemType type;
    [TextArea(15,20)]
    public string description;

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }

}

[System.Serializable]
public class Item
{
    public string Name;
    public int ID;
    public Item(ItemObject item)
    {
        Name = item.name;
        ID = item.ID;
    }
}

