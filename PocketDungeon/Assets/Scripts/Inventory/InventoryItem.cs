[System.Serializable]
public class InventoryItem
{
    public string id;
    public int level;
    public bool isEquipped;

    public InventoryItem(string id, int level, bool isEquipped = false)
    {
        this.id = id;
        this.level = level;
        this.isEquipped = isEquipped;
    }
}