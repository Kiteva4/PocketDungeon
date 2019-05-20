using UnityEngine;

[CreateAssetMenu()]
public abstract class Equipment : ScriptableObject, IEquipment
{
    [SerializeField] protected string id;
    public string ID => id;

    [SerializeField] protected Sprite itemIcon;
    public Sprite ItemIcon => itemIcon;

    private static PlayerStats _player;
    private static PlayerStats Player
    {
        get
        {
            if (_player == null)
                _player = FindObjectOfType<PlayerStats>();
            return _player;
        }
    }

    #region Curves
    [Tooltip("Кривая зависимости цены улучшения от текущего уровня предмета")]
    public ComplicationCurve costCurve;

    [Tooltip("Кривая зависимости величины бонусов к характеристикам игрока от текущего уровня предмета")]
    public ComplicationCurve bonusCurve;
    #endregion

    #region stats 
    public Rarity Rarity;

    public string ItemName => itemName;

    [SerializeField] private string itemName;


    [SerializeField] protected float baseUpgradeCost;

    [SerializeField] protected float baseBonusHP;

    [SerializeField] protected float baseBonusPhysicalDmg;

    public bool haveFireDmg;
    [SerializeField] protected float baseBonusFireDmg;

    public bool haveWaterDmg;
    [SerializeField] protected float baseBonusWaterDmg;

    #endregion

    private void OnValidate()
    {
        id = name;
    }

    public abstract ItemType GetEquipmentType();
    
    public void UpgradeItemLevel(InventoryItem invItem)
    {
        if (SaveManager.save.goldCount < GetUpgradeCost(invItem.level))
        {
            Debug.Log("Need more Gold");
        }
        else
        {
            SaveManager.save.goldCount-= GetUpgradeCost(invItem.level);
            invItem.level++;
        }
    }

    /// <summary>
    /// Вызывается при надевании предмета для перерасчета характеристик игрока
    /// </summary>
    public void EquipItem(int level)
    {
        Player.HP.BonusValue += GetItemBonusHP(level);
        Player.PhysicalDmg.BonusValue += GetItemBonusPhysicalDmg(level);

        //Вторичные параметры
        if (haveFireDmg)
            Player.FireDmg.BonusValue += GetItemBonusFireDmg(level);

        if (haveWaterDmg)
            Player.WaterDmg.BonusValue += GetItemBonusWaterDmg(level);
    }

    /// <summary>
    /// Вызывается при снятии предмета для перерасчета характеристик игрока
    /// </summary>
    public void DepriveItem(int level)
    {
        Player.HP.BonusValue -= GetItemBonusHP(level);
        Player.PhysicalDmg.BonusValue -= GetItemBonusPhysicalDmg(level);

        //Вторичные параметры
        if (haveFireDmg)
            Player.FireDmg.BonusValue -= GetItemBonusFireDmg(level);

        if (haveWaterDmg)
            Player.WaterDmg.BonusValue -= GetItemBonusWaterDmg(level);
    }


    public void RecalculateBonusStats(int level)
    {
        DepriveItem(level);
        EquipItem(level);
    }

    public void SellItem(int level) => SaveManager.save.goldCount += GetSellCost(level);

    //TODO !Create separate class for item stats!
    public float GetUpgradeCost(int level) => baseUpgradeCost * Mathf.Pow(1.12f, level);

    public float GetSellCost(int level) => 0.25f * GetUpgradeCost(level);

    public float GetItemBonusHP(int level) => ((int)Rarity * (int)Rarity + baseBonusHP)* Mathf.Pow(1.09f, level);

    public float GetItemBonusPhysicalDmg(int level) => ((int)Rarity * (int)Rarity + baseBonusPhysicalDmg) * Mathf.Pow(1.09f, level);

    public float GetItemBonusFireDmg(int level) => ((int)Rarity * (int)Rarity + baseBonusFireDmg) * Mathf.Pow(1.09f, level);

    public float GetItemBonusWaterDmg(int level) => ((int)Rarity * (int)Rarity + baseBonusWaterDmg) * Mathf.Pow(1.09f, level);
}