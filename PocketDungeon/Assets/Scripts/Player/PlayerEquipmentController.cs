using System;
using System.Reflection;
using UnityEngine;

public class PlayerEquipmentController : MonoBehaviour
{
    #region Head slot
    public int headLevel;
    private HeadEquipment _head;
    #endregion

    #region Chest slot
    public int chestLevel;
    private ChestEquipment _chest;
    #endregion

    #region Legs slot
    public int legsLevel;
    private LegsEquipment _legs;
    #endregion

    #region Weapon slot
    public int weaponLevel;
    private WeaponEquipment _weapon;
    #endregion

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
        //Уже надето
        if (equip == _head) return;

        Equip_HeadSlot(equip, level);
    }

    private void Equip(ChestEquipment equip, int level)
    {
        //Уже надето
        if (equip == _chest) return;

        Equip_ChestSlot(equip, level);
    }

    private void Equip(LegsEquipment equip, int level)
    {
        //Уже надето
        if (equip == _legs) return;

        Equip_LegsSlot(equip, level);
    }

    private void Equip(WeaponEquipment equip, int level)
    {
        //Уже надето
        if (equip == _weapon) return;

        Equip_WeaponSlot(equip, level);
    }


    //////////////////////////////////////////////////////////////////////////////////
    private void Equip_HeadSlot(HeadEquipment head, int level)
    {
        if (_head != null)
            _head.DepriveItem(level);
        _head = head;
        headLevel = level;
        _head.EquipItem(level);
    }

    private void Equip_ChestSlot(ChestEquipment chest, int level)
    {
        if (_chest != null)
            _chest.DepriveItem(level);
        _chest = chest;
        chestLevel = level;
        _chest.EquipItem(level);
    }

    private void Equip_LegsSlot(LegsEquipment legs, int level)
    {
        if (_legs != null)
            _legs.DepriveItem(level);
        _legs = legs;
        legsLevel = level;
        _legs.EquipItem(level);
    }

    private void Equip_WeaponSlot(WeaponEquipment weapon, int level)
    {
        if (_weapon != null)
            _weapon.DepriveItem(level);
        _weapon = weapon;
        weaponLevel = level;
        _weapon.EquipItem(level);
    }
}