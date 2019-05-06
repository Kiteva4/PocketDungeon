using System;
using UnityEngine;
[CreateAssetMenu(fileName = "FloatVariable", menuName = "Game/Variables/FloatVariable")]
public class FloatVariable : ScriptableObject
{
#if UNITY_EDITOR
	[Multiline]
	public string DeveloperDescription = "";
#endif
	public float Value;

	public void SetValue(float value)
	{
		Value = value;
	}

	public void SetValue(FloatVariable value)
	{
		Value = value.Value;
	}

	public void AddToValue(float amount)
	{
		Value += amount;
	}

	public void AddToValue(FloatVariable amount)
	{
		Value += amount.Value;
	}

    public static implicit operator float(FloatVariable reference)
    {
        return reference.Value;
    }
}
