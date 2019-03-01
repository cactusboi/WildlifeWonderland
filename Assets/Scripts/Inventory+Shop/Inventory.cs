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