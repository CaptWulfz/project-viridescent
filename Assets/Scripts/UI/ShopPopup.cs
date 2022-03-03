using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPopup : Popup
{
    [Header("Model")]
    [SerializeField] ShopItems shopItems;

    [Header("Global Shop Item Components")]
    [SerializeField] ShopItem shopItemRef;
    [SerializeField] Transform shopItemGroupRef;

    [Header("Seed Shop Item Objects")]
    [SerializeField] Transform seedShopItemsParent;
    
    List<ShopItem> seedShopItems;

    public void Setup()
    {
        this.seedShopItems = new List<ShopItem>();
        this.shopItemGroupRef.gameObject.SetActive(false);
        this.shopItemRef.gameObject.SetActive(false);

        Transform newItemGroup = null;
        foreach (SeedItem seedItem in this.shopItems.seedItems)
        {
            int index = Array.IndexOf<SeedItem>(this.shopItems.seedItems, seedItem);

            if (index % 2 == 0)
            {
                newItemGroup = Instantiate<Transform>(this.shopItemGroupRef, this.seedShopItemsParent);
                newItemGroup.gameObject.SetActive(true);
            }

            ShopItem newItem = Instantiate<ShopItem>(this.shopItemRef, newItemGroup);
            newItem.Setup(seedItem);
            newItem.gameObject.SetActive(true);
            this.seedShopItems.Add(newItem);
        }
    }
}
