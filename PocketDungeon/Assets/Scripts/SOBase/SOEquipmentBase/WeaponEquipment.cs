using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Game/Equipment/Weapon")]
public class WeaponEquipment : Equipment
{
    public WeaponEquipment(int level) : base(level) { }
}

