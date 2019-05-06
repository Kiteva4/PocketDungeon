using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthController : MonoBehaviour, IHealth
{
	[SerializeField] 
	protected IntReference playerLevel;
	[SerializeField]
	protected FloatReference playerMaxHP;
	[SerializeField]
	protected FloatVariable playerCurrentHP;

	[SerializeField]
	protected UnityEvent PlayerTakeDamageEvent;
	[SerializeField]
	protected UnityEvent PlayerDeathEvent;

	private void OnEnable()
	{
		playerCurrentHP.Value = playerMaxHP;
	}
	public void TakeDamage(float amount)
	{
		playerCurrentHP.AddToValue(-amount);
			PlayerTakeDamageEvent.Invoke();
		if (playerCurrentHP.Value <= 0)
			PlayerDeathEvent.Invoke();
	}

	public void TakeHeal(float amount)
	{
		playerCurrentHP.AddToValue(amount);
		if (playerCurrentHP.Value >= playerMaxHP)
			playerCurrentHP.Value = playerMaxHP;
	}
}