[System.Serializable]
public class InventoryItem
{
    public string id;
    public int level;

    public InventoryItem(string id, int level)
    {
        this.id = id;
        this.level = level;
    }
}


