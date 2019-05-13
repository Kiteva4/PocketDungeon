using UnityEngine;

[CreateAssetMenu(fileName = "TypeOfArmy", menuName = "Game/Army/ArmyUnit")]
public class Army : ScriptableObject
{
    [SerializeField] protected Sprite unitIcon;
    public Sprite UnitIcon => unitIcon;

    [SerializeField] private string unitName;
    [SerializeField] private int count;
    [SerializeField] public float baseUpgradeCost;
    [SerializeField] private float baseDamage;
    [SerializeField] private float multipler = 1.15f;

    //[SerializeField] protected FloatVariable gameGold;

    public float GetBuyCost(int count)
    {
        return Mathf.Pow(multipler, (float)(count + 1f)) * baseUpgradeCost;
    }

    public float GetDamage(int count)
    {
        if (count == 0) return 0;
        return baseDamage * Mathf.Pow(multipler, count);
    }

    public void UpgradeUnitCount(ArmyUnit au)
    {
        if (SaveManager.save.goldCount < GetBuyCost(au.unitCount))
        {
            Debug.Log("Need more Gold");
        }
        else
        {
            SaveManager.save.goldCount-=GetBuyCost(au.unitCount);
            au.unitCount++;
        }
    }
}
