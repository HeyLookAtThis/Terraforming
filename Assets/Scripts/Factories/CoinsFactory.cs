using UnityEngine;

public class CoinsFactory
{
    private CoinFactoryConfig _config;
    private CoinsStorage _storage;

    public CoinsFactory(CoinFactoryConfig config)
    {
        _config = config;

        string storageName = "CoinStorage";
        _storage = new CoinsStorage(storageName);
    }

    public ObjectsStorage Storage => _storage;
    private bool Created => _storage.Count == _config.Count;

    public void Run()
    {
        if (Created)
            return;

        while (_storage.Count < _config.Count)
        {
            Coin coin = Object.Instantiate(_config.Prefab, _storage.Transform);
            _storage.Add(coin);
        }
    }

    public void Clear()
    {
        for (int i = 0; i < _storage.Count; i++)
            _storage.GetCoin(i).ReturnToDefaultState();
    }
}
