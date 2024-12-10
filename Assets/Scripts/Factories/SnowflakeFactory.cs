using UnityEngine;

public class SnowflakeFactory
{
    private SnowflakeFactoryConfig _config;
    private LevelCounter _levelCounter;

    private ObjectsStorage _storage;

    public SnowflakeFactory(SnowflakeFactoryConfig config, LevelCounter levelCounter)
    {
        _config = config;
        _levelCounter = levelCounter;

        string storageName = "SnowflakeStorage";
        _storage = new ObjectsStorage(storageName);
    }

    public ObjectsStorage Storage => _storage;

    public void Run()
    {
        while (_storage.Count < _levelCounter.CurrentLevel)
        {
            Snowflake snowflake = Object.Instantiate(_config.Prefab, _storage.Transform);
            _storage.Add(snowflake);
        }
    }
}
