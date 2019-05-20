using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public InventoryData inventoryData = new InventoryData();
    public ArmyData armyData = new ArmyData();
    public float goldCount;

    public int bossLevel;
    public Rarity bossRarity;

    public List<Box> PlayerBoxes;

    //todo
    //public SpellProgressData spellProgressData;
    //public CurrencyData currencyData;
}
