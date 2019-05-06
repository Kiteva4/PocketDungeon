[System.Serializable]
public class Stat
{
    public FloatVariable BaseValue;

    private float _bonusValue;
    /// <summary>
    /// Бонус к стате от предмета
    /// </summary>
    public float BonusValue
    {
        get => _bonusValue;
        set
        {
            if (value < 0)
                _bonusValue = 0;
            _bonusValue = value;
        }
    }

    /// <summary>
    /// Итоговая величина статы с учетом всех бонусов от вещей
    /// </summary>
    public float CurrentValue
    {
        get => BaseValue.Value + BonusValue;
    }
}