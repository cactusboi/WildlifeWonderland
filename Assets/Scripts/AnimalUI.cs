using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalUI : MonoBehaviour
{
    public List<Item> Items = new List<Item>();
    public Transform ItemsParent;
    public AnimalSlot[] itemSlots;

    Inventory inventory;
    

    AnimalSlot[] slots;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = ItemsParent.GetComponentsInChildren<AnimalSlot>();
    }


    void Update()
    {

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
                Debug.Log("clearing inventory slots?");//slots[i].ClearSlot();
            }

        }
        //Debug.Log("UPDATING UI");
    }
}