using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentData", menuName = "Game/EquipmentData")]
public class GameEquipmentData : ScriptableObject
{
    public List<Equipment> Items;
    public List<Equipment> Common;
    public List<Equipment> Rare;
    public List<Equipment> Epic;
    public List<Equipment> Legendary;

    [ContextMenu("ReSort")]
    private void ReSort()
    {
        Clear();
        foreach (var v in Items)
        {
            switch (v.itemRarity)
            {
                case Rarity.Legendary:
                    if (!Legendary.Contains(v))
                        Legendary.Add(v);
                    break;
                case Rarity.Epic:
                    if (!Epic.Contains(v))
                        Epic.Add(v);
                    break;
                case Rarity.Rare:
                    if (!Rare.Contains(v))
                        Rare.Add(v);
                    break;
                case Rarity.Common:
                    if (!Common.Contains(v))
                        Common.Add(v);
                    break;
                default:
                    Debug.LogError($"{v.name} with unexpected rarity type");
                    break;
            }
        }
    }

    private void Clear()
    {
        Common.Clear();
        Rare.Clear();
        Epic.Clear();
        Legendary.Clear();
    }
}
