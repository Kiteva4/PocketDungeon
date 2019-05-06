using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class InventoryElement : MonoBehaviour
{
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

    [SerializeField] protected TextMeshProUGUI itemName;
    [SerializeField] protected TextMeshProUGUI statDesc;
    [SerializeField] protected TextMeshProUGUI itemLevel;
    [SerializeField] protected TextMeshProUGUI sellCost;
    [SerializeField] protected TextMeshProUGUI upgradeCost;

    [SerializeField] protected GameObject equipButton;
    [SerializeField] protected GameObject upgradeButton;
    [SerializeField] protected GameObject sellButton;
    [SerializeField] protected Image itemImg;
    [SerializeField] protected UnityEvent UpdateStats;
    [SerializeField] protected UnityEvent UpdateGold;

    private void Awake()
    {
        equipButton.GetComponent<Button>().onClick.AddListener(delegate { HandlerOnClickEquipButton(); });
        upgradeButton.GetComponent<Button>().onClick.AddListener(delegate { HandlerOnClickUpgradeButton(); });
        sellButton.GetComponent<Button>().onClick.AddListener(delegate { HandlerOnClickSellButton(); });
    }

    public void AddItemOnThisSlot(Equipment eq, InventoryItem invItem)
    {
        EquipItem = eq;
        //if (EquipItem == null) Debug.Log("EquipItem == null");

        InvItem = invItem;
        //Debug.Log(InvItem.level + " " + invItem.id);

        itemName.text = eq.itemName;
        UpgradeDesk(eq);
        itemImg.sprite = eq.ItemIcon;
    }

    private void UpgradeDesk(Equipment eq)
    {
        sellCost.text = eq.GetSellCost(invItem.level).ToString("0");
        upgradeCost.text = eq.GetUpgradeCost(invItem.level).ToString("0");
        itemLevel.text = invItem.level.ToString("0");
    }

    private void SellInventoryElement()
    {
        EquipItem.SellItem(invItem.level);
        GetComponentInParent<InventoryBuilder>().RemoveItem(gameObject);
    }

    #region Handlers
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
        UpgradeDesk(EquipItem);
    }

    public void HandlerOnClickSellButton()
    {
        SellInventoryElement();
        UpdateGold.Invoke();
        UpgradeDesk(EquipItem);
    }
    #endregion
}