using UnityEngine;

[CreateAssetMenu(fileName = "Legs", menuName = "Game/Equipment/Legs")]
public class LegsEquipment : Equipment
{
    public override ItemType GetEquipmentType()
    {
        return ItemType.Legs;
    }
}

