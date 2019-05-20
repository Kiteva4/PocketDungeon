using System.Collections;
using UnityEngine;

public class ArmyManager : MonoBehaviour
{
    [SerializeField] private GameArmyData allArmies;
    [SerializeField] private BossHealthController _bossHealthController;
    [SerializeField] private BossHealthController bossHealthController
    {
        get
        {
            if (_bossHealthController == null)
                _bossHealthController = FindObjectOfType<BossHealthController>();
            return _bossHealthController;
        }
    }
    public void InitArmiesUnit()
    {
        foreach (var a in allArmies.units)
        {
            var au = new ArmyUnit(a.name,0);
            SaveManager.save.armyData.units.Add(au);
        }
    }

    public void WakeUpArmy()
    {
        for(int i = 0; i < allArmies.units.Count; i++)
        {
            StartCoroutine(TickDamage(allArmies.units[i], SaveManager.save.armyData.units[i]));
        }
    }

    private IEnumerator TickDamage(Army army, ArmyUnit unit)
    {
        //Debug.Log($"Init curatine {army} with count {unit.unitCount}");
        while(true)
        {
            bossHealthController.OnArmyDamageTick(army.GetDamage(unit.unitCount));
            yield return new WaitForSeconds(1f);
        }
    }
}
