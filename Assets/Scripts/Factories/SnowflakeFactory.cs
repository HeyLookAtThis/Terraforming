using UnityEngine;

public class SnowflakeFactory
{
    private SnowflakeFactoryConfig _config;
    private LevelCounter _levelCounter;

    private SnowflakesStorage _storage;

    public SnowflakeFactory(SnowflakeFactoryConfig config, LevelCounter levelCounter, SnowflakesStorage storage)
    {
        _config = config;
        _levelCounter = levelCounter;
        _storage = storage;
    }

    public void Run()
    {
        while (_storage.Count < _levelCounter.CurrentLevel)
        {
            Snowflake snowflake = Object.Instantiate(_config.Prefab, _storage.Transform);
            _storage.Add(snowflake);
        }
    }
}
