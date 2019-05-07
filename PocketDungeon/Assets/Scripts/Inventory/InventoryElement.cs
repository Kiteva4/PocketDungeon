using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class InventoryElement : MonoBehaviour
{
    #region Instances
    private static PlayerEquipmentController _playerEC;
    private static PlayerEquipmentController PlayerEC
    {
        get
        {
            if (_playerEC == null)
                _playerEC = FindObjectOfType<PlayerEquipmentController>();
            return _playerEC;
        }
    }

    private Equipment _equipment;
    public Equipment EquipItem
    {
        get => _equipment;
        set => _equipment = value;
    }


    private InventoryItem invItem;
    public InventoryItem InvItem
    {
        get => invItem;
        set => invItem = value;
    }
    #endregion

    #region UI links
    [SerializeField] protected TextMeshProUGUI itemName;
    [SerializeField] protected TextMeshProUGUI statDesc;
    [SerializeField] protected TextMeshProUGUI itemLevel;
    [SerializeField] protected TextMeshProUGUI sellCost;
    [SerializeField] protected TextMeshProUGUI upgradeCost;

    [SerializeField] protected GameObject equipButton;
    [SerializeField] protected GameObject upgradeButton;
    [SerializeField] protected GameObject sellButton;
    [SerializeField] protected Image itemImg;
    #endregion

    #region UI update events
    [SerializeField] protected UnityEvent UpdateStats;
    [SerializeField] protected UnityEvent UpdateGold;
    #endregion


    private void Awake()
    {
        equipButton.GetComponent<Button>().onClick.AddListener(HandlerOnClickEquipButton);
        upgradeButton.GetComponent<Button>().onClick.AddListener(HandlerOnClickUpgradeButton);
        sellButton.GetComponent<Button>().onClick.AddListener(HandlerOnClickSellButton);
    }

    public void AddItemOnThisSlot(Equipment eq, InventoryItem invItem)
    {
        EquipItem = eq;
        //if (EquipItem == null) Debug.Log("EquipItem == null");

        InvItem = invItem;
        //Debug.Log(InvItem.level + " " + invItem.id);

        itemName.text = eq.itemName;
        itemImg.sprite = eq.ItemIcon;

        UpgradeDesk();
    }

    /// <summary>
    /// Обновление описания предмета в ячейке (уровень, цена продажи и апгрейда)
    /// </summary>
    private void UpgradeDesk()
    {
        sellCost.text = EquipItem.GetSellCost(invItem.level).ToString("0");
        upgradeCost.text = EquipItem.GetUpgradeCost(invItem.level).ToString("0");
        itemLevel.text = invItem.level.ToString("0");
    }

    /// <summary>
    /// Удаление элемента из сохраненного списка и вызов перестройки "контент вью"
    /// </summary>
    private void SellInventoryElement()
    {
        EquipItem.SellItem(invItem.level);
        GetComponentInParent<InventoryBuilder>().RemoveItem(gameObject);
    }

    #region Button click handlers

    public void HandlerOnClickEquipButton()
    {
        PlayerEC.Equip(EquipItem, invItem.level);
        UpdateStats.Invoke();
    }

    public void HandlerOnClickUpgradeButton()
    {
        EquipItem.UpgradeItemLevel(ref invItem);
        UpdateStats.Invoke();
        UpdateGold.Invoke();
        UpgradeDesk();
    }

    public void HandlerOnClickSellButton()
    {
        SellInventoryElement();
        UpdateGold.Invoke();
        UpgradeDesk();
    }
    #endregion
}