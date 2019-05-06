using System;
using System.Collections.Generic;

[Serializable]
public struct SaveData
{
    public List<InventoryItem> weaponsData;
    public List<InventoryItem> headsData;
    public List<InventoryItem> chestData;
    public List<InventoryItem> legsData;
}
