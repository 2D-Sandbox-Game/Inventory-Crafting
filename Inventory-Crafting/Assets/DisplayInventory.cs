using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public int xStart;
    public int yStart;
    public int xSpaceBetweenItems;
    private int NumberOfColums = 10;
    public int ySpaceBetweenItems;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString();
            }
            else
            {
                InstatiateItemInDisplay(i);
            }
        }
    }
    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            InstatiateItemInDisplay(i);
        }
    }

    public void InstatiateItemInDisplay(int i)
    {
        var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
        obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
        obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString();
        itemsDisplayed.Add(inventory.Container[i], obj);
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + (xSpaceBetweenItems * (i % NumberOfColums)), yStart - (ySpaceBetweenItems * (i / NumberOfColums)), 0f);
    }
}
