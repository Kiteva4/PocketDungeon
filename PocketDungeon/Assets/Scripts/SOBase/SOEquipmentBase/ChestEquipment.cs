using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Chest", menuName = "Game/Equipment/Chest")]
public class ChestEquipment : Equipment
{
    public override ItemType GetEquipmentType()
    {
        return ItemType.Chest;
    }
}

