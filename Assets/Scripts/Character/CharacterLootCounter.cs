using UnityEngine.Events;

public class CharacterLootCounter
{
    private int _coinsValue;
    private int _snowflakesValue;

    private UnityAction<int> _coinsValueChanged;
    private UnityAction<int> _snowflakesValueChanged;

    public event UnityAction<int> CoinAdded
    {
        add => _coinsValueChanged += value;
        remove => _coinsValueChanged -= value;
    }

    public event UnityAction<int> SnowflakeAdded
    {
        add => _snowflakesValueChanged += value;
        remove => _snowflakesValueChanged -= value;
    }

    public int SnowflakesValue => _snowflakesValue;
    public int CoinsValue => _coinsValue;

    public void ResetValues()
    {
        _coinsValue = 0;
        _coinsValueChanged?.Invoke(_coinsValue);

        _snowflakesValue = 0;
        _snowflakesValueChanged?.Invoke(_snowflakesValue);
    }

    public void Add(Loot loot)
    {
        switch (loot)
        {
            case Coin:
                AddValue(ref _coinsValue, _coinsValueChanged);
                break;

            case Snowflake:
                AddValue(ref _snowflakesValue, _snowflakesValueChanged);
                break;
        }
    }

    public void RemoveSnowflake() => RemoveValue(ref _snowflakesValue, _snowflakesValueChanged);

    private void AddValue(ref int value, UnityAction<int> valueChanged)
    {
        value++;
        valueChanged?.Invoke(value);
    }

    private void RemoveValue(ref int value, UnityAction<int> valueChanged)
    {
        value--;
        valueChanged?.Invoke(value);
    }
}
