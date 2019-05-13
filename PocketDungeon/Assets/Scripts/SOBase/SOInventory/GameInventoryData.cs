using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "Game/InventoryData")]
public class GameInventoryData : ScriptableObject
{
    [SerializeField] public List<InventoryItem> inventoryItems;
}
