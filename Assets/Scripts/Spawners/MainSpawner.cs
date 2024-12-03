using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawner
{
    private MainFactory _mainFactory;
    private LevelBoundariesMarker _marker;

    private CoinsSpawner _coinsSpawner;

    public MainSpawner(MainFactory mainFactory, LevelBoundariesMarker marker)
    {
        _mainFactory = mainFactory;
        _marker = marker;
        _coinsSpawner = new CoinsSpawner(mainFactory.Coins, _marker);
    }

    public CoinsSpawner CoinsSpawner => _coinsSpawner;

    public void Run()
    {
        _coinsSpawner.Run();
    }
}
