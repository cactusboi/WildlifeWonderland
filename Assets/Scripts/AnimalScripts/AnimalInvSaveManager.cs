using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AnimalInvSaveManager
{

    public static void LoadOrInitializeAnimalInventory()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "animalinventory.json")))
        {
            Debug.Log("loading animalinventory.json");
            AnimalInventory.LoadFromJSON(Path.Combine(Application.persistentDataPath, "animalinventory.json "));
        }
        else
        {
            Debug.Log("couldn't find animalinventory, loading from template.");
            AnimalInventory.InitializeFromDefault();
        }
    }
    public static void SaveAnimalInventory()
    {
        AnimalInventory.Instance.SaveToJSON(Path.Combine(Application.persistentDataPath, "animalinventory.json"));
    }

    public static void LoadFromTemplate()
    {
        AnimalInventory.InitializeFromDefault();
    }
}
