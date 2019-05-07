public interface IItemFactory
{
    IEquipment GetCommonItem();
    IEquipment GetRareItem();
    IEquipment GetEpicItem();
    IEquipment GetLegendaryItem();
}