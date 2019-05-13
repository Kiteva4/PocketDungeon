public interface IItemFactory
{
    Equipment GetRandomItem();
    Equipment GetCommonItem();
    Equipment GetRareItem();
    Equipment GetEpicItem();
    Equipment GetLegendaryItem();
}