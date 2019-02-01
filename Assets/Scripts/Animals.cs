using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour {

    #region Singleton

    public static Animal instance;
    
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Animal found");
            return;
        }
        instance = this;
    }
    #endregion

  
    


    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    


    public List<Item> Items = new List<Item>();
    public Transform itemsParent;
    public AnimalSlot[] animalSlots;

/*
    public void OnValidate()
    {
        if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<AnimalSlot>();
        

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
        
    }*/
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
}
