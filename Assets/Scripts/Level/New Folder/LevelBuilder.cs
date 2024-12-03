using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelBuilder : MonoBehaviour, IInitializable
{
    private CoinsSpawner _coinSpawner;
    private LevelBoundariesMarker _marker;

    private MainFactory _mainFactory;
    private MainSpawner _mainSpawner;

    public void Initialize()
    {
        _mainFactory.Run();
        _mainSpawner.Run();
    }

    [Inject]
    private void Construnct(Terrain terrain, MainFactoryConfig config, LevelBoundariesMarker levelBoundariesMarker)
    {
        _marker = levelBoundariesMarker;
        _mainFactory = new MainFactory(config);
        _mainSpawner = new MainSpawner(_mainFactory, levelBoundariesMarker);
    }
}
