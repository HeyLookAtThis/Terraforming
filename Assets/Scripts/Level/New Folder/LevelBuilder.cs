using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelBuilder : MonoBehaviour, IInitializable
{
    private LevelConfig _config;

    private LevelBoundariesMarker _marker;
    private LevelCounter _counter;

    private CoinsSpawner _coinSpawner;

    private MainFactory _mainFactory;
    private MainSpawner _mainSpawner;

    public void Initialize()
    {
        _mainFactory.Run();
        _mainSpawner.Run();
    }

    [Inject]
    private void Construnct(Terrain terrain, MainFactoryConfig factoryConfig, LevelConfig levelConfig, LevelBoundariesMarker levelBoundariesMarker, GrassPainter grassPainter)
    {
        _marker = levelBoundariesMarker;
        _counter = new LevelCounter(levelConfig.CounterConfig);
        _mainFactory = new MainFactory(factoryConfig, _counter, grassPainter);
        _mainSpawner = new MainSpawner(_mainFactory, levelBoundariesMarker);
    }
}
