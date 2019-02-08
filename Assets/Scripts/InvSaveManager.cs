using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InvSaveManager {

	public static void LoadOrInitializeInventory()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "inventory.json")))
        {
            Debug.Log("loading inventory.json");
            Inventory.LoadFromJSON(Path.Combine(Application.persistentDataPath, "inventory.json "));
        }
        else
        {
            Debug.Log("couldn't find inventory, loading from template.");
            Inventory.InitializeFromDefault();
        }
    }
    public static void SaveInventory()
    {
        Inventory.Instance.SaveToJSON(Path.Combine(Application.persistentDataPath, "inventory.json"));
    }

    public static void LoadFromTemplate()
    {
        Inventory.InitializeFromDefault();
    }
}
