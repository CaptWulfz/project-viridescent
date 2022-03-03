using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedShopItem : ShopItem
{
    [Header("Seed Item Model")]
    private SeedItem seedItemModel;
    public void Setup(SeedItem seedItem)
    {
        this.seedItemModel = seedItem;
        
        //SetupInfo((InventoryItem) this.seedItemModel, this.seedItemModel.Name, this.seedItemModel.Sprite, this.seedItemModel.Value, this.seedItemModel.Description);
    }
}
