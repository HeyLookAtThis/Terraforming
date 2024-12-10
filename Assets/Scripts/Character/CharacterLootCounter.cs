using UnityEngine.Events;

public class CharacterLootCounter
{
    private int _coinsValue;
    private int _snowflakesValue;

    private UnityAction<int> _coinAdded;
    private UnityAction<int> _snowflakeAdded;

    public event UnityAction<int> CoinAdded
    {
        add => _coinAdded += value;
        remove => _coinAdded -= value;
    }

    public event UnityAction<int> SnowflakeAdded
    {
        add => _snowflakeAdded += value;
        remove => _snowflakeAdded -= value;
    }

    public void ResetValues()
    {
        _coinsValue = 0;
        _coinAdded?.Invoke(_coinsValue);

        _snowflakesValue = 0;
        _snowflakeAdded?.Invoke(_snowflakesValue);
    }

    public void Add(Loot loot)
    {
        switch (loot)
        {
            case Coin:
                AddCoin();
                break;

            case Snowflake:
                AddSnowflake();
                break;
        }
    }

    private void AddCoin()
    {
        _coinsValue++;
        _coinAdded?.Invoke(_coinsValue);
    }

    private void AddSnowflake()
    {
        _snowflakesValue++;
        _snowflakeAdded?.Invoke(_snowflakesValue);
    }
}
