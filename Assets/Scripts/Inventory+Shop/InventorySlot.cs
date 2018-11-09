using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {



    public Image Icon;
    public Text ItemName;
    public Text ItemDescription;


    public Item _item;
    public Item Item
    {
        get { return _item; }
        set { _item = value;

            if (_item == null)
            {
                Icon.enabled = false;
                ItemName.enabled = false;
                ItemDescription.enabled = false;
            }
            else
            {
                Icon.sprite = _item.Icon;
                Icon.enabled = true;
                ItemName.enabled = true;
                ItemDescription.enabled = true;
                ItemName.text = Item.stringItemName;
                ItemDescription.text = Item.ItemDescription;
            }
        }

}
    private void OnValidate()
    {
        if (Icon == null)
            Icon = GetComponent<Image>();
    }

    

    Item AnItem;

    public void AddItem(Item NewItem)
    {
        AnItem = NewItem;

        Icon.sprite = AnItem.Icon;
        Icon.enabled = true;
        ItemName.enabled = true;
        ItemDescription.enabled = true;

    }

    public void ClearSlot ()
    {
        AnItem = null;

        Icon.sprite = null;
        Icon.enabled = false;
        ItemName.enabled = false;
        ItemDescription.enabled = false;
    }

}
