using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ArmyViewElement : MonoBehaviour
{
    [SerializeField] protected UnityEvent OnGoldChange;

    private Army _army;
    private Army army
    {
        get => _army;
        set => _army = value;
    }

    private ArmyUnit _armyUnit;
    public  ArmyUnit armyUnit
    {
        get => _armyUnit;
        set => _armyUnit = value;
    }

    #region UI links
    [SerializeField] protected TextMeshProUGUI armyUnitName;
    [SerializeField] protected TextMeshProUGUI armyDPS;
    [SerializeField] protected TextMeshProUGUI armyBuyUnitCost;
    [SerializeField] protected TextMeshProUGUI armyUnitCount;

    [SerializeField] protected Button buyButton;
    [SerializeField] protected Image unitImg;
    #endregion

    private void Awake()
    {
        buyButton.onClick.AddListener(HandlerOnClickBuyButton);
    }

    public void AddUnitOnThisSlot(Army army, ArmyUnit armyUnit)
    {
        this.army = army;
        this.armyUnit = armyUnit;

        UpdateUI();
    }

    private void UpdateUI()
    {
        armyUnitName.text = armyUnit.unitName;
        unitImg.sprite = army.UnitIcon;

        armyBuyUnitCost.text = army.GetBuyCost(armyUnit.unitCount).Converter();

        armyDPS.text = army.GetDamage(armyUnit.unitCount).Converter();

        armyUnitCount.text = armyUnit.unitCount.ToString();

        UpgradeUpgradableInfo();
    }

    private void UpgradeUpgradableInfo()
    {
        if(army.GetBuyCost(armyUnit.unitCount) > SaveManager.save.goldCount)
        {
            //Debug.Log($"{armyUnit.unitName} closed");
            buyButton.interactable =false;
            buyButton.image.color = Color.gray;
            armyBuyUnitCost.color = Color.red;
        }

        else
        {
            //Debug.Log($"{armyUnit.unitName} opened");

            buyButton.interactable = true;
            buyButton.image.color = Color.grey;
            armyBuyUnitCost.color = Color.green;
        }
    }

    public void HandlerOnClickBuyButton()
    {
        army.UpgradeUnitCount(armyUnit);
        OnGoldChange?.Invoke();
        UpdateUI();
    }

    public void GoldUpdateListener()
    {
        //Debug.Log("---GoldUpdateListener");
        UpgradeUpgradableInfo();
    }
}
