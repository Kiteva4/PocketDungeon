using UnityEngine;

public class ItemFactory : IItemFactory
{
    private GameEquipmentData itemsData;

    private ItemFactory() { }

    public ItemFactory(GameEquipmentData itemsData)
    {
        this.itemsData = itemsData;
    }

    public Equipment GetRandomItem()
    {
        float roll = Random.Range(0f, 100f);

        if (roll >= 95f)
        {

            return GetLegendaryItem();
        }

        if (roll >= 80f)
        {
            return GetEpicItem();

        }

        if (roll >= 50f)
        {
            return GetRareItem();
        }

        return GetCommonItem();
    }

    public Equipment GetCommonItem()
    {
        return itemsData.Common[Random.Range(0, itemsData.Common.Count - 1)];
    }

    public Equipment GetEpicItem()
    {
        return itemsData.Epic[Random.Range(0, itemsData.Epic.Count - 1)];
    }

    public Equipment GetLegendaryItem()
    {
        return itemsData.Legendary[Random.Range(0, itemsData.Legendary.Count - 1)];
    }

    public Equipment GetRareItem()
    {
        return itemsData.Rare[Random.Range(0, itemsData.Rare.Count - 1)];
    }
}