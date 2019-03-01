using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public List<InventorySlot> inventorySlots;

    private void Start()
    {
        inventorySlots = new List<InventorySlot>();
        inventorySlots.AddRange(GameObject.FindObjectsOfType<InventorySlot>());

        inventorySlots.Sort((a, b) => a.index - b.index);

        PopulateInitial();
    }

    public void PopulateInitial()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            Item instance;
            if (Inventory.Instance.GetItem(i, out instance))
            {
                inventorySlots[i].SetItem(instance);
            }
        }
    }

    public void Clear()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            inventorySlots[i].RemoveItem();
            
        }
    }
}