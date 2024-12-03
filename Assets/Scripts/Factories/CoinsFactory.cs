using System.Collections.Generic;
using UnityEngine;

public class CoinsFactory
{
    private CoinFactoryConfig _config;
    private List<Coin> _coins;

    public CoinsFactory(CoinFactoryConfig config) => _config = config;

    public int Count => _coins.Count;

    public void Run()
    {
        int createdCount = 0;
        _coins = new List<Coin>();
        GameObject storage = new GameObject("CoinStorage");

        while(createdCount < _config.Count)
        {
            Coin coin = Object.Instantiate(_config.Prefab, storage.transform);
            _coins.Add(coin);
            createdCount++;
        }
    }

    public IInteractiveObject GetCoin(int index) => _coins[index];
}
