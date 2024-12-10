using UnityEngine;
using Zenject;

public class CountDisplayerMediator : MonoBehaviour
{
    [SerializeField] private CountDisplayer _displayer;

    private CharacterLootCounter _counter;
    private VolcanoFactory _volcanoFactory;

    private void OnEnable()
    {
        _counter.CoinAdded += _displayer.ShowCoins;
        _counter.SnowflakeAdded += _displayer.ShowSnowflakes;
    }

    private void OnDisable()
    {
        _counter.CoinAdded -= _displayer.ShowCoins;
        _counter.SnowflakeAdded -= _displayer.ShowSnowflakes;
    }

    [Inject]
    private void Construct(Character character, LevelBuilder levelBuilder)
    {
        _counter = character.LootCounter;
        _volcanoFactory = levelBuilder.MainFactory.Volcanoes;
    }
}
