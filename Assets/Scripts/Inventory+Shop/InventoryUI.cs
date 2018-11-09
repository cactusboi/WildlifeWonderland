using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public Transform ItemsParent;

    Inventory inventory;

    InventorySlot[] slots;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = ItemsParent.GetComponentsInChildren<InventorySlot>();
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
                slots[i].ClearSlot();
            }

        }
        //Debug.Log("UPDATING UI");
    }
}