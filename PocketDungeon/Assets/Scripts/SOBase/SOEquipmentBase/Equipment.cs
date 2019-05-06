using UnityEngine;
using UnityEditor;

[CreateAssetMenu()]
public abstract class Equipment : ScriptableObject
{
    [SerializeField] private string id;
    public string ID => id;

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

    [Tooltip("Кривая зависимости цены улучшения от текущего уровня предмета")]
    public ComplicationCurve costCurve;

    [Tooltip("Кривая зависимости величины бонусов к характеристикам игрока от текущего уровня предмета")]
    public ComplicationCurve bonusCurve;

    [SerializeField] protected Sprite itemIcon;
    public Sprite ItemIcon
    {
        get
        {
            return itemIcon;
        }
    }

    public Rarity itemRarity;

    public string itemName;

    //[SerializeField] protected int _itemLevel;
    //public int ItemLevel
    //{
    //    get => _itemLevel;
    //    set
    //    {
    //        _itemLevel = value;
    //    }
    //}

    [SerializeField] protected float baseUpgradeCost;

    [SerializeField] protected float baseBonusHP;

    [SerializeField] protected float baseBonusPhysicalDmg;

    public bool haveFireDmg;
    [SerializeField] protected float baseBonusFireDmg;

    public bool haveWaterDmg;
    [SerializeField] protected float baseBonusWaterDmg;

    [SerializeField] protected FloatVariable gameGold;


    private void OnValidate()
    {
        Debug.Log("Validate");
        //string path = AssetDatabase.GetAssetPath(this);
        //id = AssetDatabase.AssetPathToGUID(path);
        id = GetInstanceID().ToString();
    }

    public Equipment(int level)
    {
        //ItemLevel = level;

        //SetRarity();

        itemName = name + GetHashCode().ToString();
    }

    public void SetRarity()
    {
        float roll = Random.Range(0f, 100f);

        if (roll >= 95)
            itemRarity = Rarity.Legendary;
        else if (roll >= 80)
            itemRarity = Rarity.Epic;
        else if (roll >= 50)
            itemRarity = Rarity.Rare;
        else
            itemRarity = Rarity.Common;
    }

    public void UpgradeItemLevel(ref InventoryItem invItem)
    {
        if (gameGold.Value < GetUpgradeCost(invItem.level))
        {
            Debug.Log("Need more Gold");
        }
        else
        {
            gameGold.AddToValue(-GetUpgradeCost(invItem.level));
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

    public void SellItem(int level)
    {
        gameGold.Value += GetSellCost(level);
    }

    public float GetUpgradeCost(int level)
    {
        return baseUpgradeCost + costCurve.GetEvaluate(level);
    }

    public float GetItemBonusHP(int level)
    {
        return (int)itemRarity * baseBonusHP + bonusCurve.GetEvaluate(level);
    }

    public float GetItemBonusPhysicalDmg(int level)
    {
        return (int)itemRarity * baseBonusPhysicalDmg + bonusCurve.GetEvaluate(level);
    }

    public float GetItemBonusFireDmg(int level)
    {
        return (int)itemRarity * baseBonusFireDmg + bonusCurve.GetEvaluate(level);
    }

    public float GetItemBonusWaterDmg(int level)
    {
        return (int)itemRarity * baseBonusWaterDmg + bonusCurve.GetEvaluate(level);
    }

    public float GetSellCost(int level)
    {
        return 0.25f * GetUpgradeCost(level);
    }
}
