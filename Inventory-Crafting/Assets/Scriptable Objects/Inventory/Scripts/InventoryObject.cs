using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory", menuName ="Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemObject item, int amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == item) // checks if ítem is already in the inventory
            {
                Container[i].AddAmount(amount); // adds amount to existing item
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            Container.Add(new InventorySlot(item, amount));
        }
    }
}
[System.Serializable]
public class InventorySlot // combines a given item in a slot with an amount
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
    public void SubAmount(int value)
    {
        if (amount > value)
        {
            amount -= value;
        }
        else
        {
            Debug.Log("Not enough items");
        }
    }
}
