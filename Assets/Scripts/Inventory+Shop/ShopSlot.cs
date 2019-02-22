using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Image Icon;
    public Text ItemName;
    public Text ItemDescription;
    public Text ItemPriceString;
    //calling game manager so you can get currency
    public GameManager GameManager;
    


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

    Item AnItem;

    //purchase item
    public void OnClick()
    {
        //PlayerPrefs.GetInt("Money", MoneyShop);
        if (GameManager.Money >= Item.ItemPrice)
        {
            Debug.Log(Item.name + " purchased.");
            GameManager.Money -= Item.ItemPrice;
            //update ui and save currency
            GameManager.MoneyText.text = "$" + GameManager.Money.ToString();
            PlayerPrefs.SetInt("Money", GameManager.Money);
            PlayerPrefs.Save();

            if(Inventory.Instance != null)
            {
                Inventory.Instance.InsertItem(Item);
            }
            else
            Debug.Log("item is invalid");

        }
        else
        {
            Debug.Log("Not enough money (" + GameManager.Money + ").");
        }
    }
    public void AddItem(Item NewItem)
    {
        AnItem = NewItem;

        Icon.sprite = AnItem.Icon;
        Icon.enabled = true;
        ItemName.enabled = true;
        ItemDescription.enabled = true;
        ItemPriceString.enabled = true;

    }
/*
    public void ClearSlot()
    {
        AnItem = null;

        Icon.sprite = null;
        Icon.enabled = false;
        ItemName.enabled = false;
        ItemDescription.enabled = false;
        ItemPriceString.enabled = false;
    }*/

}
