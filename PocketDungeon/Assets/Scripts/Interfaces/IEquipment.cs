public interface IEquipment
{
    void UpgradeItemLevel(ref InventoryItem level);
    void SellItem(int level);
    void EquipItem(int level);
    void DepriveItem(int level);
}
