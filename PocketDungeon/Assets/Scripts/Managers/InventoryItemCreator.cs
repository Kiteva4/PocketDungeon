[System.Serializable]
public class InventoryItemCreator
{
    /// <summary>
    /// Экземпляр фабрики, которая будет создавать инстансы обьектов
    /// </summary>
    private IItemFactory factory;
    /// <summary>
    /// класс, содержащий информацию об одетом в конкретный слот предмете
    /// </summary>
    private IEquipmentSlot equipmentSlot;
    /// <summary>
    /// Ссылка на класс, содержащий предметы инвентаря
    /// </summary>
    private InventoryItemsData inventoryItems;
    /// <summary>
    /// Создает предметы из фабрики и помещает их в инвентарь
    /// </summary>
    /// <param name="gameEquipmentData"> хранилище игровых предметов для создания экземпляра фабрики </param>
    /// <param name="equipmentSlot"> уровень предмета данного типа (тип, создаваемый фабрикой) на персонаже </param>
    /// <param name="inventoryItems"> список предметов персонажа в данном списке инвентаря</param>
    public InventoryItemCreator(GameEquipmentData gameEquipmentData, IEquipmentSlot equipmentSlot, InventoryItemsData inventoryItems, ItemType creationItemsType)
    {
        factory = new ItemFactory(gameEquipmentData);
        this.equipmentSlot = equipmentSlot;
        this.inventoryItems = inventoryItems;
        this.creationItemsType = creationItemsType;
    }
    public ItemType creationItemsType;
    public void AddRandomItem(int? level = null, bool? isEquipped = null)
    {
        Equipment equipment = factory.GetRandomItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? equipmentSlot.GetSLotLevel(), isEquipped ?? false);
        //Debug.Log("ссылки совпадают? : " + ReferenceEquals(inventoryItems, SaveManager.save.inventoryData.weaponsData)); 
        inventoryItems.items.Add(item);
    }

    public void AddNewCommonItem(int? level = null, bool? isEquipped = null)
    {
        Equipment equipment = factory.GetCommonItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? equipmentSlot.GetSLotLevel(), isEquipped ?? false);
        inventoryItems.items.Add(item);
    }

    public void AddNewRareItem(int? level = null, bool? isEquipped = null)
    {
        Equipment equipment = factory.GetRareItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? equipmentSlot.GetSLotLevel(), isEquipped ?? false);
        inventoryItems.items.Add(item);
    }

    public void AddNewEpicItem(int? level = null, bool? isEquipped = null)
    {
        Equipment equipment = factory.GetEpicItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? equipmentSlot.GetSLotLevel(), isEquipped ?? false);
        inventoryItems.items.Add(item);
    }

    public void AddNewLegendaryItem(int? level = null, bool? isEquipped = null)
    {
        Equipment equipment = factory.GetLegendaryItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? equipmentSlot.GetSLotLevel(), isEquipped ?? false);
        inventoryItems.items.Add(item);
    }

    public Equipment GetItem(Rarity rarity)
    {
        Equipment equipment;

        switch (rarity)
        {
            case Rarity.Legendary:
                equipment = factory.GetLegendaryItem();
                return equipment;
            case Rarity.Epic:
                equipment = factory.GetEpicItem();
                return equipment;
            case Rarity.Rare:
                equipment = factory.GetRareItem();
                return equipment;
            case Rarity.Common:
                equipment = factory.GetCommonItem();
                return equipment;
            default:
                equipment = factory.GetRandomItem();
                return equipment;
        }
    }

    public void AddItem(Equipment equipment, int? level = null, bool ? isEquipped = null)
    {
        InventoryItem item = new InventoryItem(equipment.ID, level ?? equipmentSlot.GetSLotLevel(), isEquipped ?? false);
        inventoryItems.items.Add(item);
    }
}