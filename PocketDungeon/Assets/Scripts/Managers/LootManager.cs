using UnityEngine;

public class LootManager : MonoBehaviour
{
    [SerializeField] private GameEquipmentData allWeaponsData;
    [SerializeField] private GameEquipmentData allHeadsData;
    [SerializeField] private GameEquipmentData allChestsData;
    [SerializeField] private GameEquipmentData allLegsData;

    private InventoryItemCreator weaponCreator;
    private InventoryItemCreator headCreator;
    private InventoryItemCreator chestCreator;
    private InventoryItemCreator legCreator;

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

    private void InitCreators()
    {
        weaponCreator = new InventoryItemCreator(allWeaponsData, PlayerEC.weaponSlot, SaveManager.save.inventoryData.weaponsData);
        headCreator = new InventoryItemCreator(allHeadsData, PlayerEC.headSlot, SaveManager.save.inventoryData.headsData);
        chestCreator = new InventoryItemCreator(allChestsData, PlayerEC.chestSlot, SaveManager.save.inventoryData.chestsData);
        legCreator = new InventoryItemCreator(allLegsData, PlayerEC.legSlot, SaveManager.save.inventoryData.legsData);
    }

    #region Init equipments
    public void InitPlayerEquipments()
    {
        InitCreators();
    }

    public void CollectFirstEquipments()
    {
        if (weaponCreator == null && headCreator == null && chestCreator == null && legCreator == null)
        {
            InitCreators();
        }

        weaponCreator.AddNewCommonItem(1, true);
        headCreator.AddNewCommonItem(1,true);
        chestCreator.AddNewCommonItem(1,true);
        legCreator.AddNewCommonItem(1,true);
    }

    public void InitEquipLoadedItems()
    {
        FindToEquip(SaveManager.save.inventoryData.weaponsData, allWeaponsData);
        FindToEquip(SaveManager.save.inventoryData.headsData, allHeadsData);
        FindToEquip(SaveManager.save.inventoryData.chestsData, allChestsData);
        FindToEquip(SaveManager.save.inventoryData.legsData, allLegsData);
    }

    private void FindToEquip(InventoryItemsData save, GameEquipmentData dataBase)
    {
        foreach (var v in save.items)
        {
            if (v.isEquipped == true)
            {
                PlayerEC.Equip(GetEquipment(v.id, dataBase), v.level);
                return;
            }
        }
        Debug.Log($"can faind on {save} equipment items");
    }

    private Equipment GetEquipment(string id, GameEquipmentData data)
    {
        foreach (var item in data.Items)
        {
            if (item.ID == id)
            {
                return item;
            }
        }

        Debug.LogError($"return null cant get{id} on {data.name}");
        return null;
    }
    #endregion


    //TODO удалить
    public void OnClickCreateWepon()
    {
        weaponCreator.AddRandomItem(2);
        //Debug.Log("create weapon");
    }

    public void OnClickCreateHead()
    {
        headCreator.AddRandomItem(2);
        //Debug.Log("create head");
    }

    public void OnClickCreateChest()
    {
        chestCreator.AddRandomItem(3);
        //Debug.Log("create chest");
    }

    public void OnClickCreateLeg()
    {
        legCreator.AddNewCommonItem(1);
        //Debug.Log("create leg");
    }

    public void OnCreateRandomItem()
    {
        int i = Random.Range(1, 4);
        switch (i)  
        {
            case 1:
                weaponCreator.AddRandomItem(PlayerEC.weaponSlot.level);
                Debug.Log("weaponCreator AddRandomItem");
                break;
            case 2:
                headCreator.AddRandomItem(PlayerEC.headSlot.level);
                Debug.Log("headCreator AddRandomItem");
                break;
            case 3:
                chestCreator.AddRandomItem(PlayerEC.chestSlot.level);
                Debug.Log("chestCreator AddRandomItem");
                break;
            case 4:
                legCreator.AddNewCommonItem(PlayerEC.legSlot.level);
                Debug.Log("legCreator AddRandomItem");
                break;
            default:
                break;
        }
    }
}