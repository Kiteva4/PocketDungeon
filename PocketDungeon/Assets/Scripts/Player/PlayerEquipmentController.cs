using System.Reflection;
using UnityEngine;

public class PlayerEquipmentController : MonoBehaviour 
{
    public EquipmentSlot headSlot;
    public EquipmentSlot chestSlot;
    public EquipmentSlot legSlot;
    public EquipmentSlot weaponSlot;

    public void Equip(Equipment equip, int level)
    {
        var type = equip.GetType();

        if (type == typeof(HeadEquipment))
            Equip((HeadEquipment)equip, level);
        else if (type == typeof(ChestEquipment))
            Equip((ChestEquipment) equip, level);
        else if (type == typeof(LegsEquipment))
            Equip((LegsEquipment) equip, level);
        else if (type == typeof(WeaponEquipment))
            Equip((WeaponEquipment) equip, level);
    }

    //////////////////////////////////////////////////////////////////////////////////
    private void Equip(HeadEquipment equip, int level)
    {
        Equip_HeadSlot(equip, level);
    }

    private void Equip(ChestEquipment equip, int level)
    {
        Equip_ChestSlot(equip, level);
    }

    private void Equip(LegsEquipment equip, int level)
    {
        Equip_LegsSlot(equip, level);
    }

    private void Equip(WeaponEquipment equip, int level)
    {
        Equip_WeaponSlot(equip, level);
    }


    //////////////////////////////////////////////////////////////////////////////////
    private void Equip_HeadSlot(HeadEquipment head, int level)
    {
        if (headSlot.equipment != null)
            headSlot.equipment.DepriveItem(headSlot.level);
        headSlot.equipment = head;
        headSlot.level = level;
        headSlot.equipment.EquipItem(level);
    }

    private void Equip_ChestSlot(ChestEquipment chest, int level)
    {
        if (chestSlot.equipment != null)
            chestSlot.equipment.DepriveItem(chestSlot.level);
        chestSlot.equipment = chest;
        chestSlot.level = level;
        chestSlot.equipment.EquipItem(level);
    }

    private void Equip_LegsSlot(LegsEquipment legs, int level)
    {
        if (legSlot.equipment != null)
            legSlot.equipment.DepriveItem(legSlot.level);
        legSlot.equipment = legs;
        legSlot.level = level;
        legSlot.equipment.EquipItem(level);
    }

    private void Equip_WeaponSlot(WeaponEquipment weapon, int level)
    {
        if (weaponSlot.equipment != null)
            weaponSlot.equipment.DepriveItem(weaponSlot.level);
        weaponSlot.equipment = weapon;
        weaponSlot.level = level;
        weaponSlot.equipment.EquipItem(level);
    }
}
