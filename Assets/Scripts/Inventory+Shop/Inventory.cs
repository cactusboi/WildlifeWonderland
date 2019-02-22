using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Items/Inventory", fileName = "Inventory.asset")]
[System.Serializable]

public class Inventory : ScriptableObject
{
    private static Inventory _instance;
    public static Inventory Instance
    {
        get
        {
            if (!_instance)
            {
                Inventory[] tmp = Resources.FindObjectsOfTypeAll<Inventory>();
                if (tmp.Length > 0)
                {
                    _instance = tmp[0];
                    Debug.Log("found inventory: " + _instance);
                }
                else
                {
                    Debug.Log("No inventory found, loading from template/file.");
                    InvSaveManager.LoadOrInitializeInventory();
                }
            }
            return _instance;
        }

    }
    public static void InitializeFromDefault()
    {
        if (_instance)
            DestroyImmediate(_instance);
        _instance = Instantiate((Inventory)Resources.Load("InventoryTemplate"));
        _instance.hideFlags = HideFlags.HideAndDontSave;
    }

    public static void LoadFromJSON(string path)
    {
        if (_instance)
            DestroyImmediate(_instance);
        _instance = ScriptableObject.CreateInstance<Inventory>();
        JsonUtility.FromJsonOverwrite(System.IO.File.ReadAllText(path), _instance);
        _instance.hideFlags = HideFlags.HideAndDontSave;
    }

    public void SaveToJSON(string path)
    {
        Debug.LogFormat("saving to {0}", path);
        System.IO.File.WriteAllText(path, JsonUtility.ToJson(this, true));
    }

    public Item[] inventory;

    public bool SlotEmpty(int index)
    {
        if (inventory[index] == null || inventory[index].item == null)
        {
            return true;
        }
        return false;
    }

    public bool GetItem(int index, out Item item)
    {
        if (SlotEmpty(index))
        {
            item = null;
            return false;
        }
        item = inventory[index];
        return true;
    }
    public bool RemoveItem(int index)
    {
        if (SlotEmpty(index))
        {
            // Nothing existed at the specified slot.
            return false;
        }

        inventory[index] = null;

        return true;
    }
    //insert item and return index where it was inserted
    public int InsertItem(Item item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (SlotEmpty(i))
            {
                inventory[i] = item;
                return i;
            }
        }
        //no free slot
        Debug.Log("no free slot");
        return -1;
    }

    private void Save()
    {
        InvSaveManager.SaveInventory();
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;
    
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }
        instance = this;
    }
    #endregion

  
    


    //public delegate void OnItemChanged();
    //public OnItemChanged onItemChangedCallback;
    


    List<Item> Items = new List<Item>();
   // public Transform itemsParent;
   // public InventorySlot[] itemSlots;

/*
    public void OnValidate()
    {
        if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<InventorySlot>();
        

        RefreshUI();
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
    public void Add (Item AnItem)
    {
        Items.Add(AnItem);
        
        if (onItemChangedCallback!= null)
        onItemChangedCallback.Invoke();
    }

    public void Remove(Item AnItem)
    {
        Items.Remove(AnItem);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}*/
