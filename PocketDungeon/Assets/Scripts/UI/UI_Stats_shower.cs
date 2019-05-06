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
        hp.text = ps.HP.CurrentValue.ToString("0");
        p_dmg.text = ps.PhysicalDmg.CurrentValue.ToString("0");
        f_dmg.text = ps.FireDmg.CurrentValue.ToString("0");
        w_dmg.text = ps.WaterDmg.CurrentValue.ToString("0");
    }
}
