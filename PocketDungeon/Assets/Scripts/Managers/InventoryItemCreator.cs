using UnityEngine;

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
    
    private InventoryItemCreator() { }

    /// <summary>
    /// Создает предметы из фабрики и помещает их в инвентарь
    /// </summary>
    /// <param name="gameEquipmentData"> хранилище игровых предметов для создания экземпляра фабрики </param>
    /// <param name="equipmentSlot"> уровень предмета данного типа (тип, создаваемый фабрикой) на персонаже </param>
    /// <param name="inventoryItems"> список предметов персонажа в данном списке инвентаря</param>
    public InventoryItemCreator(GameEquipmentData gameEquipmentData, IEquipmentSlot equipmentSlot, InventoryItemsData inventoryItems)
    {
        factory = new ItemFactory(gameEquipmentData);
        this.equipmentSlot = equipmentSlot;
        this.inventoryItems = inventoryItems;
    }

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
}