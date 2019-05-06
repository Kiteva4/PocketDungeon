using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDamageController : MonoBehaviour, IDamageDealer
{
    [SerializeField]
    protected FloatVariable BaseDamge;
    [SerializeField]
    protected FloatVariable PhysicalDamge;
    [SerializeField]
    protected FloatVariable FireDamge;
    [SerializeField]
    protected FloatVariable WaterDamge;
    [Space(20)]
    [SerializeField]
    protected UnityEvent PlayerDealDamageEvent;

    public void DealDamage(int amount)
    {
        PlayerDealDamageEvent.Invoke();
    }

    public void CalcDamage()
    {

    }
}
