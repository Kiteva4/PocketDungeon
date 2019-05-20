using UnityEngine;

public class PlayerEquipmentController : MonoBehaviour 
{
    public EquipmentSlot[] Slot = new EquipmentSlot[(int)ItemType.count];

    public void Equip(Equipment equip, int level)
    {
        if (Slot[(int)equip.GetEquipmentType()].equipment != null)
            Slot[(int)equip.GetEquipmentType()].equipment.DepriveItem(Slot[(int)equip.GetEquipmentType()].level);
        Slot[(int)equip.GetEquipmentType()].equipment = equip;
        Slot[(int)equip.GetEquipmentType()].level = level;
        Slot[(int)equip.GetEquipmentType()].equipment.EquipItem(level);
    }
}
