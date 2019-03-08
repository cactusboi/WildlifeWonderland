using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Items/AnimalInventory", fileName = "AnimalInventory.asset")]
[System.Serializable]

public class AnimalInventory : ScriptableObject
{
    private static AnimalInventory _instance;
    public static AnimalInventory Instance
    {
        get
        {
            if (!_instance)
            {
                AnimalInventory[] tmp = Resources.FindObjectsOfTypeAll<AnimalInventory>();
                if (tmp.Length > 0)
                {
                    _instance = tmp[0];
                    Debug.Log("found Animalinventory: " + _instance);
                }
                else
                {
                    Debug.Log("No Animalinventory found, loading from template/file.");
                    AnimalInvSaveManager.LoadOrInitializeAnimalInventory(); //maybe can be in invsavemanager
                }
            }
            return _instance;
        }

    }
    public static void InitializeFromDefault()
    {
        if (_instance)
            DestroyImmediate(_instance);
        _instance = Instantiate((AnimalInventory)Resources.Load("AnimalInventoryTemplate"));
        _instance.hideFlags = HideFlags.HideAndDontSave;
    }

    public static void LoadFromJSON(string path)
    {
        if (_instance)
            DestroyImmediate(_instance);
        _instance = ScriptableObject.CreateInstance<AnimalInventory>();
        JsonUtility.FromJsonOverwrite(System.IO.File.ReadAllText(path), _instance);
        _instance.hideFlags = HideFlags.HideAndDontSave;
    }

    public void SaveToJSON(string path)
    {
        Debug.LogFormat("saving to {0}", path);
        System.IO.File.WriteAllText(path, JsonUtility.ToJson(this, true));
    }

    public Animals[] animalinventory;

    public bool SlotEmpty(int index)
    {
        if (animalinventory[index] == null || animalinventory[index].animal == null)
        {
            return true;
        }
        return false;
    }

    public bool GetAnimal(int index, out Animals animal)
    {
        if (SlotEmpty(index))
        {
            animal = null;
            return false;
        }
        animal = animalinventory[index];
        return true;
    }
    public bool RemoveAnimal(int index)
    {
        if (SlotEmpty(index))
        {
            // Nothing existed at the specified slot.
            return false;
        }

        animalinventory[index] = null;

        return true;
    }
    //insert item and return index where it was inserted
    public int InsertAnimal(Animals animal)
    {
        for (int i = 0; i < animalinventory.Length; i++)
        {
            if (SlotEmpty(i))
            {
                animalinventory[i] = animal;
                return i;
            }
        }
        //no free slot
        Debug.Log("no free slot");
        return -1;
    }

    private void Save()
    {
        AnimalInvSaveManager.SaveAnimalInventory();
    }
}