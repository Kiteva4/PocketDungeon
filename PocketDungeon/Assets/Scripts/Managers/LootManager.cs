using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    [SerializeField] private GameEquipmentData allWeaponsData;
    [SerializeField] private GameEquipmentData allHeadsData;
    [SerializeField] private GameEquipmentData allChestsData;
    [SerializeField] private GameEquipmentData allLegsData;

    private ItemFactory weaponFactory;
    private ItemFactory headFactory;
    private ItemFactory chestFactory;
    private ItemFactory legFactory;


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

    private void Awake()
    {
        weaponFactory = new ItemFactory(allWeaponsData);
        headFactory = new ItemFactory(allHeadsData);
        chestFactory = new ItemFactory(allChestsData);
        legFactory = new ItemFactory(allLegsData);
    }

    #region Weapon creations
    public void AddNewRandomWeaponToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)weaponFactory.GetRandomItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.weaponLevel);
        SaveManager.save.inventoryData.weapons.Add(item);
    }

    public void AddNewCommonWeaponToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)weaponFactory.GetCommonItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.weaponLevel);
        SaveManager.save.inventoryData.weapons.Add(item);
    }

    public void AddNewRareWeaponToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)weaponFactory.GetRareItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.weaponLevel);
        SaveManager.save.inventoryData.weapons.Add(item);
    }

    public void AddNewEpicWeaponToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)weaponFactory.GetEpicItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.weaponLevel);
        SaveManager.save.inventoryData.weapons.Add(item);
    }

    public void AddNewLegendaryWeaponToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)weaponFactory.GetLegendaryItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.weaponLevel);
        SaveManager.save.inventoryData.weapons.Add(item);
    }
    #endregion

    #region Head creations
    public void AddNewRandomHeadToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)headFactory.GetRandomItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.headLevel);
        SaveManager.save.inventoryData.heads.Add(item);
    }

    public void AddNewCommonHeadToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)headFactory.GetCommonItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.headLevel);
        SaveManager.save.inventoryData.heads.Add(item);

    }

    public void AddNewRareHeadToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)headFactory.GetRareItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.headLevel);
        SaveManager.save.inventoryData.heads.Add(item);
    }

    public void AddNewEpicHeadToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)headFactory.GetEpicItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.headLevel);
        SaveManager.save.inventoryData.heads.Add(item);
    }

    public void AddNewLegendaryHeadToInventory(int? level = null)
    {
        Equipment equipment;
        equipment = (Equipment)headFactory.GetCommonItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.headLevel);
        SaveManager.save.inventoryData.heads.Add(item);
    }
    #endregion

    #region Chest creations
    public void AddNewRandomChestToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)chestFactory.GetRandomItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.chestLevel);
        SaveManager.save.inventoryData.chests.Add(item);
    }

    public void AddNewCommonChestToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)chestFactory.GetCommonItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.chestLevel);
        SaveManager.save.inventoryData.chests.Add(item);
    }

    public void AddNewRareChestToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)chestFactory.GetRareItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.chestLevel);
        SaveManager.save.inventoryData.chests.Add(item);
    }

    public void AddNewEpicChestToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)chestFactory.GetEpicItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.chestLevel);
        SaveManager.save.inventoryData.chests.Add(item);
    }

    public void AddNewLegendaryChestToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)chestFactory.GetLegendaryItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.chestLevel);
        SaveManager.save.inventoryData.chests.Add(item);
    }
    #endregion

    #region Leg creations
    public void AddNewRandomLegToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)legFactory.GetRandomItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.legsLevel);
        SaveManager.save.inventoryData.legs.Add(item);
    }

    public void AddNewCommonLegToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)legFactory.GetCommonItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.legsLevel);
        SaveManager.save.inventoryData.legs.Add(item);
    }

    public void AddNewRareLegToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)legFactory.GetRareItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.legsLevel);
        SaveManager.save.inventoryData.legs.Add(item);
    }

    public void AddNewEpicLegToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)legFactory.GetEpicItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.legsLevel);
        SaveManager.save.inventoryData.legs.Add(item);
    }

    public void AddNewLegendaryLegToInventory(int? level = null)
    {
        Equipment equipment = (Equipment)legFactory.GetLegendaryItem();
        InventoryItem item = new InventoryItem(equipment.ID, level ?? _playerEC.legsLevel);
        SaveManager.save.inventoryData.legs.Add(item);
    }
    #endregion

    #region Init equipments
    public void InitPlayerEquipments()
    {
        if (weaponFactory == null && headFactory == null && chestFactory == null && legFactory == null)
        {
            Debug.LogError("factories is empty");
            return;
        }
        AddNewCommonWeaponToInventory(1);
        AddNewCommonHeadToInventory(2);
        AddNewCommonChestToInventory(3);
        AddNewCommonLegToInventory(4);
    }
    #endregion
}
