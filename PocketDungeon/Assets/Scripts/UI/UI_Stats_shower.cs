using UnityEngine;
using TMPro;
public class UI_Stats_shower : MonoBehaviour
{
    private PlayerStats _ps;
    private PlayerStats ps
    {
        get
        {
            if (_ps == null)
                _ps = FindObjectOfType<PlayerStats>();
            return _ps;
        }
    }

    [SerializeField] private TextMeshProUGUI hp;
    [SerializeField] private TextMeshProUGUI p_dmg;
    [SerializeField] private TextMeshProUGUI f_dmg;
    [SerializeField] private TextMeshProUGUI w_dmg;

    private void OnEnable()
    {
        UpdateStats();
    }

    public void UpdateStats()
    {
        hp.text     = ps.HP.CurrentValue.Converter();
        p_dmg.text  = ps.PhysicalDmg.CurrentValue.Converter();
        f_dmg.text  = ps.FireDmg.CurrentValue.Converter();
        w_dmg.text  = ps.WaterDmg.CurrentValue.Converter();
    }
}
