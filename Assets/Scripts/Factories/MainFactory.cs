using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFactory
{
    private MainFactoryConfig _config;
    private CoinsFactory _coinsFactory;
    private TreeFactory _treeFactory;

    public MainFactory(MainFactoryConfig config, LevelCounter levelCounter, GrassPainter grassPainter)
    {
        _config = config;
        _coinsFactory = new CoinsFactory(config.CoinFactoryConfig);
        _treeFactory = new TreeFactory(config.TreeFactoryConfig, levelCounter, grassPainter);
    }

    public CoinsFactory Coins => _coinsFactory;
    public TreeFactory Trees => _treeFactory;

    public void Run()
    {
        _coinsFactory.Run();
        _treeFactory.Run();
    }
}
