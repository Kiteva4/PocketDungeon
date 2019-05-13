using System;

[Serializable]
public class SaveData
{
    public InventoryData inventoryData = new InventoryData();
    public ArmyData armyData = new ArmyData();
    public float goldCount;

    public int bossLevel;
    public Rarity bossRarity;

    

    //todo
    //public SpellProgressData spellProgressData;
    //public CurrencyData currencyData;
}
