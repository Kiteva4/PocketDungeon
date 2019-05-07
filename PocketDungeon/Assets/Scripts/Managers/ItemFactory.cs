using UnityEngine;

public class ItemFactory : IItemFactory
{
    private GameEquipmentData itemsData;

    private ItemFactory() { }

    public ItemFactory(GameEquipmentData itemsData)
    {
        this.itemsData = itemsData;
    }

    public IEquipment GetRandomItem()
    {
        float roll = Random.Range(0f, 100f);

        if (roll >= 95)
        {

            return GetLegendaryItem();
        }

        if (roll >= 80)
        {
            return GetEpicItem();

        }

        if (roll >= 50)
        {
            return GetRareItem();
        }

        return GetCommonItem();
    }

    public IEquipment GetCommonItem()
    {
        return itemsData.Common[Random.Range(0, itemsData.Common.Count - 1)];
    }

    public IEquipment GetEpicItem()
    {
        return itemsData.Epic[Random.Range(0, itemsData.Epic.Count - 1)];
    }

    public IEquipment GetLegendaryItem()
    {
        return itemsData.Legendary[Random.Range(0, itemsData.Legendary.Count - 1)];
    }

    public IEquipment GetRareItem()
    {
        return itemsData.Rare[Random.Range(0, itemsData.Rare.Count - 1)];
    }
}