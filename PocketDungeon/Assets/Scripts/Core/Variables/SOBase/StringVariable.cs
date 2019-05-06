using UnityEngine;
[CreateAssetMenu(fileName = "StringVariable", menuName = "Game/Variables/IntVariable")]
public class StringVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    [SerializeField]
	private string value = "";

	public string Value
	{
		get { return value; }
		set { this.value = value; }
	}
}
