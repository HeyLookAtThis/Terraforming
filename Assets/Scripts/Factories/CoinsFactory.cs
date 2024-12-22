using UnityEngine;

public class CoinsFactory
{
    private CoinFactoryConfig _config;
    private CoinsStorage _storage;

    public CoinsFactory(CoinFactoryConfig config, CoinsStorage storage)
    {
        _config = config;
        _storage = storage;
    }

    public void Run()
    {
        while (_storage.Count < _config.Count)
        {
            Coin coin = Object.Instantiate(_config.Prefab, _storage.Transform);
            _storage.Add(coin);
        }
    }
}
