using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using System;

public class BossHealthController : MonoBehaviour
{
    [SerializeField] private UnityEvent OnBossDied;
    [SerializeField] private UnityEvent OnGoldCountChange;

    private PlayerStats _playerStats;
    private PlayerStats playerStats
    {
        get
        {
            if (_playerStats == null)
                _playerStats = FindObjectOfType<PlayerStats>();
            return _playerStats;
        }
    }

    private DamageShower _damageShower;
    private DamageShower damageShower
    {
        get
        {
            if (_damageShower == null)
                _damageShower = FindObjectOfType<DamageShower>();
            return _damageShower;
        }
    }

    private Rarity bossRarity
    {
        set
        {
            SaveManager.save.bossRarity = value;
        }

        get
        {
            Rarity r = SaveManager.save.bossRarity;
            bossRarityText.text = Enum.GetName(typeof(Rarity), r); ;
            return r;
        }
    }

    [SerializeField] private Image bossHeathlBar;
    [SerializeField] private TextMeshProUGUI bossCurrentHealth;
    [SerializeField] private TextMeshProUGUI bossMaxHealth;
    [SerializeField] private TextMeshProUGUI bossRarityText;
    [SerializeField] private TextMeshProUGUI bossLevelText;

    private float maxHealth
    {
        get
        {
            float maxHP = (1000 +  (int)bossRarity)* Mathf.Pow(1.15f, level);
            bossMaxHealth.text = maxHP.Converter();
            return maxHP;
        }
    }

    [SerializeField] private float _currentHealth;
    private float currentHealth
    {
        get
        {
            return _currentHealth;
        }

        set
        {
            _currentHealth = value;
            bossHeathlBar.fillAmount = _currentHealth / maxHealth;
            bossCurrentHealth.text = _currentHealth.Converter();
        }
    }

    public int level
    {
        get
        {
            return SaveManager.save.bossLevel;
        }

        set
        {
            bossLevelText.text = value.ToString();
            SaveManager.save.bossLevel = value;
        }

    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void OnPlayerTap()
    {
        TakeDamage(Color.white,playerStats.GetPhysicalDmg());
        TakeDamage(Color.red, playerStats.GetFireDmg());
        TakeDamage(Color.blue, playerStats.GetWaterDmg());
    }

    public void OnArmyDamageTick(float amount)
    {
        TakeDamage(Color.white, amount);
    }

    private void TakeDamage(Color color, float amount)
    {
        if (amount <= 0) return;

        damageShower.ShowDamage(color, amount);
        ChangeHP(amount);
    }

    private void ChangeHP(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0f;
            OnBossDied?.Invoke();

            SaveManager.save.goldCount += (8f + (float)bossRarity) * Mathf.Pow(1.15f, level);
            OnGoldCountChange?.Invoke();
            
            //TODO Перенести в BossGenerator
            GenerateBoss();
        }
    }

    private void GenerateBoss()
    {
        level++;
        bossRarity = (Rarity)(2*UnityEngine.Random.Range(1, 4));
        currentHealth = maxHealth;
    }
}