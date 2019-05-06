using UnityEngine;
using TMPro;

public class UI_GoldShower : MonoBehaviour
{
    [SerializeField] private FloatVariable goldCount;
    [SerializeField] TextMeshProUGUI goldCountText;

    private void OnEnable()
    {
        UpdateGold();
    }

    public void UpdateGold()
    {
        goldCountText.text = goldCount.Value.ToString("0");
    }
}
