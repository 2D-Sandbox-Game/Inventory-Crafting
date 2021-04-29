using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Equipment,
    Block,
    Default
}
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab; // holds display for the item
    public ItemType type;

}
