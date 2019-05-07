using System.Collections.Generic;

[System.Serializable]
public class InventoryData
{
    public List<InventoryItem> weapons = new List<InventoryItem>();
    public List<InventoryItem> heads = new List<InventoryItem>();
    public List<InventoryItem> chests = new List<InventoryItem>();
    public List<InventoryItem> legs = new List<InventoryItem>();
}