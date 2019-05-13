using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArmyData", menuName = "Game/Army/ArmyData")]
public class GameArmyData : ScriptableObject
{
    public List<Army> units = new List<Army>();
}
