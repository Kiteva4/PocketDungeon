using UnityEngine;
using UnityEngine.Events;

public class PlayerDamageController : MonoBehaviour, IDamageDealer
{
    [SerializeField]
    protected UnityEvent PlayerDealDamageEvent;

    public void GetDamage(int amount)
    {
        
    }
}
