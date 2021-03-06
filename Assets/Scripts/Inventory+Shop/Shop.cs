﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    #region Singleton

    public static Shop instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Shop found");
            return;
        }
        instance = this;
    }
    #endregion





    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;


    public List<Item> Items = new List<Item>();
    public Transform itemsParent;
    public ShopSlot[] itemSlots;

    //private int Money;


    public void OnValidate()
    {
        if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<ShopSlot>();


        RefreshUI();
    }
    public void RefreshUI()
    {
        int i = 0;
        for (; i < Items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = Items[i];
        }

        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }
    }

    /*public void PurchaseItem()
    {
        PlayerPrefs.GetInt("Money", Money);
        if (Money >= Item.ItemPrice)
        Debug.Log("Item Purchased");
    }*/
    public void Add(Item AnItem)
    {
        Items.Add(AnItem);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void Remove(Item AnItem)
    {
        Items.Remove(AnItem);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
