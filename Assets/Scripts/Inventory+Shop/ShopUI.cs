using UnityEngine;

public class ShopUI : MonoBehaviour
{

    public Transform ItemsParent;

    Shop shop;

    ShopSlot[] slots;

    void Start()
    {
        shop = Shop.instance;
        shop.onItemChangedCallback += UpdateUI;

        slots = ItemsParent.GetComponentsInChildren<ShopSlot>();
    }


    void Update()
    {

    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < shop.Items.Count)
            {
                Debug.Log("adding item to shop");//slots[i].AddItem(shop.Items[i]);
            }
            else
            {
                Debug.Log("clearing slot");//slots[i].ClearSlot();
            }

        }
        //Debug.Log("UPDATING UI");
    }
}