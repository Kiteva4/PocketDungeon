using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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

    private BoxController boxCreator;

    [SerializeField] private GameObject UI_OpenBox;
    //[SerializeField] private GameObject boxImage;
    [SerializeField] private GameObject itemImageHolder;
    [SerializeField] private GameObject boxGoldHolder;
    [SerializeField] private ParticleSystem goldAddParticleSystem;
    [SerializeField] private Animator itemImageAnimator;
    [SerializeField] private Animator boxGoldAnimator;
    //[SerializeField] private GameObject OpenNextBoxButton;
    [SerializeField] private TextMeshProUGUI boxCountText;
    [SerializeField] private Image itemImage;
    [SerializeField] private float goldInBox;

    private int _boxCount;
    public int boxCount
    {
        get => _boxCount;
        set
        {
            _boxCount = value;
            boxCountText.text = _boxCount.ToString();
        }
    }

    private void InitCreators()
    {
        weaponCreator = new InventoryItemCreator(allWeaponsData, PlayerEC.Slot[(int)ItemType.Weapon], SaveManager.save.inventoryData.weaponsData,  ItemType.Weapon);
        headCreator =   new InventoryItemCreator(allHeadsData,   PlayerEC.Slot[(int)ItemType.Head],   SaveManager.save.inventoryData.headsData,    ItemType.Head);
        chestCreator =  new InventoryItemCreator(allChestsData,  PlayerEC.Slot[(int)ItemType.Chest],  SaveManager.save.inventoryData.chestsData,   ItemType.Chest);
        legCreator =    new InventoryItemCreator(allLegsData,    PlayerEC.Slot[(int)ItemType.Legs],    SaveManager.save.inventoryData.legsData,     ItemType.Legs);
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

    public void InitBoxController()
    {
        boxCreator = new BoxController();
        boxCount = SaveManager.save.PlayerBoxes.Count;
    }

    public void InitBoxList()
    {
        SaveManager.save.PlayerBoxes = new List<Box>();
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

    public void OnCreateRandomItem()
    {
        Random.InitState((int)Time.time);

        int i = Random.Range(1, 4);
        switch (i)  
        {
            case 1:
                boxCreator.AddBox(weaponCreator,SaveManager.save.bossRarity);
                break;
            case 2:
                boxCreator.AddBox(headCreator, SaveManager.save.bossRarity);
                break;
            case 3:
                boxCreator.AddBox(legCreator, SaveManager.save.bossRarity);
                break;
            case 4:
                boxCreator.AddBox(chestCreator, SaveManager.save.bossRarity);
                break;
            default:
                break;
        }
    }

    public void HandlerOnClickOpenBox()
    {
        if(SaveManager.save.PlayerBoxes.Count!=0)
            OnClickOpenBox();
    }

    private void OnClickOpenBox()
    {
        itemImage.sprite = boxCreator.GetItemSprite();
        goldInBox = boxCreator.GetBoxGoldCount();

        if(!UI_OpenBox.activeInHierarchy)
            UI_OpenBox.SetActive(true);

        boxCreator.AddItemToInventory();
        StartCoroutine(ShowItemImage());
    }

    IEnumerator ShowItemImage()
    {
        itemImageHolder.SetActive(true);
        goldAddParticleSystem.gameObject.SetActive(false);

        itemImageAnimator.SetTrigger("Show");
        yield return new WaitForSeconds(1.2f);
#if UNITY_EDITOR
        yield return new WaitUntil(() => Input.anyKeyDown);
#else
        yield return new WaitUntil(() => Input.touchCount != 0);
#endif
        itemImageAnimator.SetTrigger("Hide");
        StartCoroutine(ShowGoldCountFromBox());
        yield return new WaitForSeconds(0.7f);
        itemImageHolder.SetActive(false);
    }

    IEnumerator ShowGoldCountFromBox()
    {
        boxGoldHolder.SetActive(true);
        boxGoldAnimator.SetTrigger("Show");
        yield return new WaitForSeconds(0.7f);
#if UNITY_EDITOR
        yield return new WaitUntil(() => Input.anyKeyDown);
#else
        yield return new WaitUntil(() => Input.touchCount != 0);
#endif
        boxGoldAnimator.SetTrigger("Hide");
        yield return new WaitForSeconds(0.6f);
        boxGoldHolder.SetActive(false);
        goldAddParticleSystem.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        if (SaveManager.save.PlayerBoxes.Count != 0)
            OnClickOpenBox();
        else
            UI_OpenBox.SetActive(false);
    }
}