using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFactory
{
    private MainFactoryConfig _config;
    private CoinsFactory _coinsFactory;

    public MainFactory(MainFactoryConfig config)
    {
        _config = config;
        _coinsFactory = new CoinsFactory(config.CoinFactoryConfig);
    }

    public CoinsFactory Coins => _coinsFactory;

    public void Run()
    {
        _coinsFactory.Run();
    }
}
