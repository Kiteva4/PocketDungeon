using UnityEngine;
using System.Collections;

[System.Serializable]
public class Loot
{
    [SerializeField] GameEquipmentData allElemetsData;
    [SerializeField] GameInventoryData inventoryElementsData;

    /// <summary>
    /// Добавление предмета в инвентарь.
    /// </summary> 
    /// <param name = "slotLevel" >Уровень создаваемого предмета.</param>
    public void AddToInventory(int slotLevel)
    {
        AddItem(slotLevel);
    }

    private void AddItem(int slotLevel)
    {
        Equipment item = allElemetsData.Items[Random.Range(0, (allElemetsData.Items.Count - 1))];
        InventoryItem iItem = new InventoryItem (item.ID, slotLevel);
        inventoryElementsData.inventoryItems.Add(iItem);
        //Debug.Log($"Added {item.itemName} to {inventoryElementsData.Items} with {item.GetHashCode()}");
    }
}
