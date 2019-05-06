using UnityEngine;
[CreateAssetMenu(fileName = "IntVariable", menuName = "Game/Variables/IntVariable")]
public class IntVariable : ScriptableObject
{
#if UNITY_EDITOR
	[Multiline]
	public string DeveloperDescription = "";
#endif
	public int Value;

	public void SetValue(int value)
	{
		Value = value;
	}

	public void SetValue(IntVariable value)
	{
		Value = value.Value;
	}

	public void AddToValue(int amount)
	{
		Value += amount;
	}

	public void AddToValue(IntVariable amount)
	{
		Value += amount.Value;
	}
}
