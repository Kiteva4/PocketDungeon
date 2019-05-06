using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    [SerializeField] protected Loot Chests;
    [SerializeField] protected Loot Heads;
    [SerializeField] protected Loot Legs;
    [SerializeField] protected Loot Weapons;

    private PlayerEquipmentController _playerEC;
    private PlayerEquipmentController PlayerEC
    {
        get
        {
            if (_playerEC == null)
                _playerEC = FindObjectOfType<PlayerEquipmentController>();
            return _playerEC;
        }
    }

    public void AddNewChestToInventory()
    {
        Chests.AddToInventory(PlayerEC.chestLevel);
    }

    public void AddNewHeadToInventory()
    {
        Heads.AddToInventory(PlayerEC.headLevel);
    }

    public void AddNewLegToInventory()
    {
        Legs.AddToInventory(PlayerEC.legsLevel);
    }

    public void AddNewWeaponToInventory()
    {
        Weapons.AddToInventory(PlayerEC.weaponLevel);
    }
}
