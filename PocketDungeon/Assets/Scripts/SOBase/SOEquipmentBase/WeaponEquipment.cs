using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Game/Equipment/Weapon")]
public class WeaponEquipment : Equipment
{
    public override ItemType GetEquipmentType()
    {
        return ItemType.Weapon;
    }
}


