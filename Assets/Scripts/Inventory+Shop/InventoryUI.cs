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
    /* public delegate void OnItemChanged();
     public OnItemChanged onItemChangedCallback;



     public List<Item> Items = new List<Item>();
     public Transform itemsParent;
     public InventorySlot[] itemSlots;
     //Inventory inventory;
     InventorySlot[] slots;

     public void OnValidate()
     {
         if (itemsParent != null)
             itemSlots = itemsParent.GetComponentsInChildren<InventorySlot>();


         RefreshUI();
     }
     void Start()
     {
         ItemChanged();

         slots = itemsParent.GetComponentsInChildren<InventorySlot>();
     }

     private void ItemChanged()
     {
         Inventory.instance.onItemChangedCallback += RefreshUI;
     }

     public void RefreshUI()
         {
             int i = 0;
             for(; i < Items.Count && i < itemSlots.Length; i++)
                 {
                 itemSlots[i].Item = Items[i];
                 }

             for (; i < itemSlots.Length; i++)
                 {
                 itemSlots[i].Item = null;
                 }

         }
     public void Add(Item AnItem)
     {
         Items.Add(AnItem);

         if (onItemChangedCallback != null)
             onItemChangedCallback.Invoke();
     }

     public void Remove(Item AnItem)
     {
         Items.Remove(AnItem);

         if (onItemChangedCallback != null)
             onItemChangedCallback.Invoke();
     }


     void UpdateUI()
     {
         for (int i = 0; i < slots.Length; i++)
         {
             if (i < inventory.Items.Count)
             {
                 slots[i].AddItem(inventory.Items[i]);
             }
             else
             {
                 Debug.Log("clearing inventory slots?????");//slots[i].ClearSlot();
             }

         }
         //Debug.Log("UPDATING UI");
     }*/
}