using UnityEngine;

public class CoinsFactory
{
    private CoinFactoryConfig _config;
    private ObjectsStorage _storage;

    public CoinsFactory(CoinFactoryConfig config)
    {
        _config = config;

        string storageName = "CoinStorage";
        _storage = new ObjectsStorage(storageName);
    }

    public ObjectsStorage Storage => _storage;

    public void Run()
    {
        while (_storage.Count < _config.Count)
        {
            Coin coin = Object.Instantiate(_config.Prefab, _storage.Transform);
            _storage.Add(coin);
        }
    }
}
