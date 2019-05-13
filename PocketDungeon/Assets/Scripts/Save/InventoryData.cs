using System;

[Serializable]
public class InventoryData
{
    public InventoryItemsData weaponsData = new InventoryItemsData();
    public InventoryItemsData headsData = new InventoryItemsData();
    public InventoryItemsData chestsData = new InventoryItemsData();
    public InventoryItemsData legsData = new InventoryItemsData();
}
