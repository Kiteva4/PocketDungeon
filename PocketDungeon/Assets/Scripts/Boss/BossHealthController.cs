using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthController : MonoBehaviour, IHealth
{
	/// <summary>
	/// Редкость босса
	/// </summary>
	public Rarity bossRarity;

	public string bossName;

	[SerializeField]
	protected FloatReference bossMaxHP;
	[SerializeField]
	protected FloatVariable bossCurrentHP;

	public void TakeDamage(float amount)
	{

	}

	public void TakeHeal(float amount) { }
}
