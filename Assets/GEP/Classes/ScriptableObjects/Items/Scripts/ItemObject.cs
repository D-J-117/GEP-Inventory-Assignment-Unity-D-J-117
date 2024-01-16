using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An enum storing different item types that can be extended
// depending on the type of game it is used in
public enum ItemType
{
    Default
}

// Base class
public abstract class ItemObject : ScriptableObject
{
    public GameObject itemPrefab;
    public GameObject displayPrefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;

}
