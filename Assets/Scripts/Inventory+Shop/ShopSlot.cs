using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Image Icon;
    public Text ItemName;
    public Text ItemDescription;
    public Text ItemPriceString;

    private int Money;


    public Item _item;
    public Item Item
    {
        get { return _item; }
        set
        {
            _item = value;

            if (_item == null)
            {
                Icon.enabled = false;
                ItemName.enabled = false;
                ItemDescription.enabled = false;
                ItemPriceString.enabled = false;
            }
            else
            {
                Icon.sprite = _item.Icon;
                Icon.enabled = true;
                ItemName.enabled = true;
                ItemDescription.enabled = true;
                ItemPriceString.enabled = true;
                ItemName.text = Item.stringItemName;
                ItemDescription.text = Item.ItemDescription;
                ItemPriceString.text = Item.ItemPrice.ToString();
            }
        }

    }
    private void OnValidate()
    {
        if (Icon == null)
            Icon = GetComponent<Image>();
    }

    /*public void PurchaseItem()
    {
        PlayerPrefs.GetInt("Money", Money);
        if (Money >= Item.ItemPrice)
            Debug.Log("Item Purchased");
    }*/

    Item AnItem;

    public void AddItem(Item NewItem)
    {
        AnItem = NewItem;

        Icon.sprite = AnItem.Icon;
        Icon.enabled = true;
        ItemName.enabled = true;
        ItemDescription.enabled = true;
        ItemPriceString.enabled = true;

    }

    public void ClearSlot()
    {
        AnItem = null;

        Icon.sprite = null;
        Icon.enabled = false;
        ItemName.enabled = false;
        ItemDescription.enabled = false;
        ItemPriceString.enabled = false;
    }

}
