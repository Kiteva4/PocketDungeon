using System;

[Serializable]
public class EquipmentSlot : IEquipmentSlot
{
    public Equipment equipment;
    //public InventoryItem equipmentInventoryItem;
    public int level;

    public int GetSLotLevel()
    {
        return level;
    }
}