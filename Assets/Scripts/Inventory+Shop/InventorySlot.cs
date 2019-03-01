using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public int index = 0;

    public Item itemInstance = null;
    //public GameObject prefabInstance = null;

    public Image Icon;
    public Text ItemName;
    public Text ItemDescription;

    public void SetItem(Item instance)
    {
        this.itemInstance = instance;


        Icon.sprite = instance.Icon;
        Icon.enabled = true;
        ItemName.enabled = true;
        ItemDescription.enabled = true;
        ItemName.text = instance.stringItemName;
        ItemDescription.text = instance.ItemDescription;

    }

    public void RemoveItem()
    {
        this.itemInstance = null;

        Icon.sprite = null;
        Icon.enabled = false;
        ItemName.enabled = false;
        ItemDescription.enabled = false;
    }
}
        /*
       
        private void OnValidate()
        {
            if (Icon == null)
                Icon = GetComponent<Image>();
        }

       */

    
