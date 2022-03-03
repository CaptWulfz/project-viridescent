[System.Serializable]
public class InventoryData
{
    public InventoryItemData[] seedItems;
    public InventoryItemData[] decorationItems;

    public InventoryData(InventoryItemData[] seeds = null, InventoryItemData[] decorations = null)
    {
        this.seedItems = seeds;
        this.decorationItems = decorations;
    }
}

[System.Serializable]
public class InventoryItemData
{
    public int stacks;
    public string item_id;
}
