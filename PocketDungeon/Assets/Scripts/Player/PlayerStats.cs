using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Stat HP;
    public Stat PhysicalDmg;
    public Stat FireDmg;
    public Stat WaterDmg;

    public float GetPhysicalDmg()
    {
        return PhysicalDmg.CurrentValue;
    }

    public float GetFireDmg()
    {
        return FireDmg.CurrentValue;
    }

    public float GetWaterDmg()
    {
        return WaterDmg.CurrentValue;
    }
}