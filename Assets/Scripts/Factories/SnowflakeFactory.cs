using UnityEngine;

public class SnowflakeFactory
{
    private SnowflakeFactoryConfig _config;
    private LevelCounter _levelCounter;

    private SnowflakeStorage _storage;

    public SnowflakeFactory(SnowflakeFactoryConfig config, LevelCounter levelCounter)
    {
        _config = config;
        _levelCounter = levelCounter;

        string storageName = "SnowflakeStorage";
        _storage = new SnowflakeStorage(storageName);
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

    public void Clear()
    {
        for (int i = 0; i < _storage.Count; i++)
        {
            Snowflake snowflake = _storage.GetSnowflake(i);
            _storage.Remove(snowflake);
            snowflake.ReturnToDefaultState();
        }
    }
}
