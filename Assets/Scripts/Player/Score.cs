using UnityEngine;
using Zenject;

public class Score : MonoBehaviour
{
    private int _value;
    private int _currentLevelValue;

    private CharacterLootCounter _lootCounter;
    private LevelCounter _levelCounter;

    public int Value => _value;
    public int EstimatedValue => _value + _currentLevelValue;

    private void OnEnable()
    {
        _lootCounter.CoinAdded += OnIncreaseTemporaryValue;
        _levelCounter.SetNextLevel += OnIncreaseValue;
    }

    private void OnDisable()
    {
        _lootCounter.CoinAdded -= OnIncreaseTemporaryValue;
        _levelCounter.SetNextLevel -= OnIncreaseValue;
    }

    public void ResetValue() => _value = 0;
    private void OnIncreaseTemporaryValue(int count) => _currentLevelValue = count;
    private void OnIncreaseValue() => _value += _currentLevelValue;

    [Inject]
    private void Construct(Character character, LevelBuilder builder)
    {
        _lootCounter = character.LootCounter;
        _levelCounter = builder.Counter;
    }
}
