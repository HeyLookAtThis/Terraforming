using UnityEngine;
using Zenject;

public class LevelBuilder : MonoBehaviour, IInitializable
{
    [SerializeField] private Transform _characterSpawnPoint;

    private LevelConfig _config;
    private LevelCounter _counter;

    private MainFactory _mainFactory;
    private MainSpawner _mainSpawner;

    private Atmosphere _atmosphere;

    public MainFactory MainFactory => _mainFactory;
    public Atmosphere Atmosphere => _atmosphere;

    public void Initialize()
    {
        _mainFactory.Run();
        _mainSpawner.Run();
    }

    public void Clear() => _mainFactory.Clear();

    [Inject]
    private void Construnct(Terrain terrain, MainFactoryConfig factoryConfig, LevelConfig levelConfig, LevelBoundariesMarker levelBoundariesMarker, GrassPainter grassPainter)
    {
        _counter = new LevelCounter(levelConfig.CounterConfig);
        _mainFactory = new MainFactory(factoryConfig, _counter, grassPainter);
        _mainSpawner = new MainSpawner(_mainFactory, levelBoundariesMarker, _characterSpawnPoint);

        _atmosphere = new Atmosphere(levelConfig.AtmosphereConfig, _mainFactory.Volcanoes.Storage.Count);
    }
}
