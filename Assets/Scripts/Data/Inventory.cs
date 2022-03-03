using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private const string INVENTORY_ITEM_PATH = "AssetFiles/{0}/{1}";

    private InventoryData inventoryData;

    private List<InventoryItemEntry> seeds;

    public void InitializeInventory()
    {
        this.seeds = new List<InventoryItemEntry>();
        if (this.inventoryData?.seedItems != null)
        {
            foreach (InventoryItemData seedItem in this.inventoryData.seedItems)
            {
                SeedItem seedItemModel = (SeedItem) LoadItemModelFromResources(seedItem.item_id);
                InventoryItemEntry newEntry = new InventoryItemEntry(seedItem.stacks, seedItemModel);
                this.seeds.Add(newEntry);
            }
        }
    }

    public void AddInventoryItem(InventoryItem item)
    {
        if (item is SeedItem)
        {
            InventoryItemEntry existingItem = this.seeds.Find((x) => { return x.inventoryItem.Name == item.Name; });
            if (existingItem == null)
                this.seeds.Add(new InventoryItemEntry(1, item));
            else
                existingItem.stack++;
        }
    }

    public InventoryItemEntry GetInventoryItem(string name)
    {
        InventoryItemEntry item = this.seeds.Find((x) => { return x.inventoryItem.Name == name; });
        return item;
    }

    private InventoryItem LoadItemModelFromResources(string itemId)
    {
        InventoryItem newItem = null;
        string folderName = "";
        string fileName = "";

        string[] idSplit = itemId.Split('_');
        string prefix = idSplit[0];
        string suffix = idSplit[1];

        if (prefix == "seed")
            folderName = "Seeds";

        if (suffix == "daisy")
            fileName = "DaisySeed";

        string fullPath = string.Format(INVENTORY_ITEM_PATH, folderName, fileName);

        if (prefix == "seed")
            newItem = Resources.Load<SeedItem>(fullPath);
        
        return newItem;
    }
}

public class InventoryItemEntry
{
    public int stack;
    public InventoryItem inventoryItem;

    public InventoryItemEntry(int stack = 0, InventoryItem item = null)
    {
        this.stack = stack;
        this.inventoryItem = item;
    }
}
