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

    private InventorySelector inventorySelector;

    private Equipment _equipment;
    public Equipment equipment
    {
        get => _equipment;
        set => _equipment = value;
    }

    private InventoryItem _inventoryItem;
    public InventoryItem inventoryItem
    {
        get => _inventoryItem;
        set
        {
            _inventoryItem = value;
        }
    }

    private bool _isEquiped;
    private bool IsEquiped
    {
        get => _isEquiped;
        set
        {
            _isEquiped = value;
            if(value == true)
            {
                HideButtonsOnEquippedElement();
            }
            else
            {
                ShowButtonsOnUnequippedElement();
            }
        }
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

        inventorySelector = GetComponentInParent<InventorySelector>();
    }

    public void AddItemOnThisSlot(Equipment equipment, InventoryItem inventoryItem)
    {
        this.equipment = equipment;
        this.inventoryItem = inventoryItem;
        IsEquiped = this.inventoryItem.isEquipped;

        itemName.text = equipment.itemName;
        itemImg.sprite = equipment.ItemIcon;

        if (IsEquiped == true) inventorySelector.SelectInventoryElement(this); //EquipThisItem();

        UpgradeDesk();
    }

    //скрывает кнопки и записывает в changeEquippedEvent (см выше на одну строчку) ссылку на метод, который включает 
    //отображения кнопок данного класса
    public void EquipThisItem()
    {
        IsEquiped = inventoryItem.isEquipped = true;
        inventorySelector.SelectInventoryElement(this);
        //Снаряжаем игрока в слот и прибавляем к статам
        PlayerEC.Equip(equipment, _inventoryItem.level);
        //Обновление визуального отображения статов игрока
        UpdateStats.Invoke();
    }

    public void UnequipThisItem()
    {
        IsEquiped = inventoryItem.isEquipped = false;
    }

    private void ShowButtonsOnUnequippedElement()
    {
        sellButton.SetActive(true);
        equipButton.SetActive(true);
    }

    private void HideButtonsOnEquippedElement()
    {
        sellButton.SetActive(false);
        equipButton.SetActive(false);
    }

    /// <summary>
    /// Обновление описания предмета в ячейке (уровень, цена продажи и апгрейда)
    /// </summary>
    private void UpgradeDesk()
    {
        sellCost.text =     equipment.GetSellCost(_inventoryItem.level).Converter();
        upgradeCost.text =  equipment.GetUpgradeCost(_inventoryItem.level).Converter();
        itemLevel.text =    _inventoryItem.level.ToString("0");
    }

    /// <summary>
    /// Удаление элемента из сохраненного списка и вызов перестройки "контент вью"
    /// </summary>
    private void SellInventoryElement()
    {
        equipment.SellItem(_inventoryItem.level);
        GetComponentInParent<InventoryBuilder>().RemoveItem(gameObject);
    }

    #region Button click handlers

    public void HandlerOnClickEquipButton()
    {
        EquipThisItem();
    }

    public void HandlerOnClickUpgradeButton()
    {
        equipment.UpgradeItemLevel(_inventoryItem);

        //если улучшаем одетый предмет - обновляем бонусы от него (переодеваем  сновым уровнем)
        if (IsEquiped == true) PlayerEC.Equip(equipment, _inventoryItem.level);

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