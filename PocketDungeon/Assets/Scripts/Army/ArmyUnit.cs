[System.Serializable]
public class ArmyUnit
{
    public string unitName;
    public int unitCount;

    private ArmyUnit() { }

    public ArmyUnit(string _name, int _count)
    {
        this.unitName = _name;
        this.unitCount = _count;
    }
}