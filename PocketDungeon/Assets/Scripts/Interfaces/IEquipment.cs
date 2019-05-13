public interface IEquipment
{
    void UpgradeItemLevel(InventoryItem level);
    void SellItem(int level);
    void EquipItem(int level);
    void DepriveItem(int level);
}
