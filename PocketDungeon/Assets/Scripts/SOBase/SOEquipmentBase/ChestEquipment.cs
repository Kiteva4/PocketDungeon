using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Chest", menuName = "Game/Equipment/Chest")]
public class ChestEquipment : Equipment
{
    public ChestEquipment(int level) : base(level)
    {
        
    }
}

