/// <summary>
/// Редкость
/// </summary>
public enum Rarity
{
	Legendary = 4,
	Epic = 3,
	Rare = 2,
	Common = 1
}

/// <summary>
/// Слот экипировки определяет тип предмета
/// </summary>
[System.Serializable]
public enum ItemType
{
	Head,
	Chest,
	Legs,
	Weapon,

    count
}

/// <summary>
/// Слот экипировки определяет тип предмета
/// </summary>
public enum Element
{
	Fire,
	Water,
	Nature,
	Air,
	Magic
}