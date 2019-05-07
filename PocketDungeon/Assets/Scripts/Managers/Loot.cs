using UnityEngine;
using System.Collections;

[System.Serializable]
public class Loot
{
    [SerializeField] GameEquipmentData allElemetsData;
    [SerializeField] private ItemType itemTypes;

    /// <summary>
    /// Добавление предмета в инвентарь.
    /// </summary> 
    /// <param name = "slotLevel" >Уровень создаваемого предмета.</param>
    public void AddToInventory(int slotLevel)
    {
        Equipment item = null;
        InventoryItem iItem = null;

        //switch (itemTypes)
        //{
        //    case ItemType.Head:
        //        item = allElemetsData.Items[Random.Range(0, (allElemetsData.Items.Count - 1))];
        //        iItem = new InventoryItem(item.ID, slotLevel);
        //        InventoryData.inventoryHeadData.Items.Add(iItem);
        //        break;
        //    case ItemType.Сhest:
        //        item = allElemetsData.Items[Random.Range(0, (allElemetsData.Items.Count - 1))];
        //        iItem = new InventoryItem(item.ID, slotLevel);
        //        InventoryData.inventoryChestData.Items.Add(iItem);
        //        break;
        //    case ItemType.Legs:
        //        item = allElemetsData.Items[Random.Range(0, (allElemetsData.Items.Count - 1))];
        //        iItem = new InventoryItem(item.ID, slotLevel);
        //        InventoryData.inventoryLegsData.Items.Add(iItem);
        //        break;
        //    case ItemType.Weapon:
        //        item = allElemetsData.Items[Random.Range(0, (allElemetsData.Items.Count - 1))];
        //        iItem = new InventoryItem(item.ID, slotLevel);
        //        InventoryData.inventoryWeaponData.Items.Add(iItem);
        //        break;
        //    default:
        //        break;
        //}
    }
}
