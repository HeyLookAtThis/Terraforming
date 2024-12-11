using UnityEngine;
using Zenject;

public class CountDisplayerMediator : MonoBehaviour
{
    [SerializeField] private CountDisplayer _displayer;

    private CharacterLootCounter _counter;
    private VolcanoFactory _volcanoFactory;

    private void OnEnable()
    {
        _counter.CoinAdded += _displayer.OnShowCoins;
        _counter.SnowflakeAdded += _displayer.OnShowSnowflakes;
        _volcanoFactory.Created += OnShowVolcanoes;
        _volcanoFactory.Storage.FrozenVolcanoesValueChanged += OnShowVolcanoes;
    }

    private void OnDisable()
    {
        _counter.CoinAdded -= _displayer.OnShowCoins;
        _counter.SnowflakeAdded -= _displayer.OnShowSnowflakes;
        _volcanoFactory.Created -= OnShowVolcanoes;
        _volcanoFactory.Storage.FrozenVolcanoesValueChanged -= OnShowVolcanoes;
    }

    private void OnShowVolcanoes() => _displayer.ShowVolcanoes(_volcanoFactory.Storage.GetFrozenCount(), _volcanoFactory.Storage.Count);

    [Inject]
    private void Construct(Character character, LevelBuilder levelBuilder)
    {
        _counter = character.LootCounter;
        _volcanoFactory = levelBuilder.MainFactory.Volcanoes;
    }
}
