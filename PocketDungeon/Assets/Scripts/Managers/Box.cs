using UnityEngine;

[System.Serializable]
public class Box
{
    private InventoryItemCreator itemCreator;

    public float _goldsOnBox;
    public float GoldsOnBox => _goldsOnBox;
    public Equipment equipment;
    public int itemLevel;

    private Rarity boxRarity;
    

    public Box(InventoryItemCreator itemCreator, Rarity boxRarity)
    {
        this.itemCreator = itemCreator;
        this.boxRarity = boxRarity;

        itemLevel = SaveManager.save.bossLevel;

        equipment = itemCreator.GetItem(boxRarity);
        SetGoldCount();
    }

    public Sprite GetItemImage()
    {
        return equipment.ItemIcon;
    }

    public void OpenBox()
    {
        AddItemToPlayerInventory();
        SaveManager.save.goldCount += GoldsOnBox;
    }

    private void AddItemToPlayerInventory()
    {
        InventoryItem item = new InventoryItem(equipment.ID, itemLevel, false);
        AddItemToInventory(item);
    }

    private void AddItemToInventory(InventoryItem item)
    {
        switch (equipment.GetEquipmentType())
        {
            case ItemType.Head:
                SaveManager.save.inventoryData.headsData.items.Add(item);
                break;
            case ItemType.Chest:
                SaveManager.save.inventoryData.chestsData.items.Add(item);
                break;
            case ItemType.Legs:
                SaveManager.save.inventoryData.legsData.items.Add(item);
                break;
            case ItemType.Weapon:
                SaveManager.save.inventoryData.weaponsData.items.Add(item);
                break;
            default:
                break;
        }
    }

    private void SetGoldCount()
    {
        int i = (int)SaveManager.save.bossRarity;
        _goldsOnBox = (i*i) * Mathf.Pow(1.12f,SaveManager.save.bossLevel);
    }
}