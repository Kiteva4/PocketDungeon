using UnityEngine;

[CreateAssetMenu(fileName = "Head", menuName = "Game/Equipment/Head")]
public class HeadEquipment : Equipment
{
    public override ItemType GetEquipmentType()
    {
        return ItemType.Head;
    }
}

