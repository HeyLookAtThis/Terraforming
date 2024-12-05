using System.Collections.Generic;
using UnityEngine;

public class SnowflakeFactory
{
    private SnowflakeFactoryConfig _config;
    private List<Snowflake> _snowflakes;
    private LevelCounter _levelCounter;

    public SnowflakeFactory(SnowflakeFactoryConfig config, LevelCounter levelCounter)
    {
        _config = config;
        _snowflakes = new List<Snowflake>();
        _levelCounter = levelCounter;
    }

    public int Count => _snowflakes.Count;

    public void Run()
    {
        int createdCount = 0;
        GameObject storage = new GameObject("SnowflakeStorage");

        while (createdCount < _levelCounter.CurrentLevel)
        {
            Snowflake snowflake = Object.Instantiate(_config.Prefab, storage.transform);
            _snowflakes.Add(snowflake);
            createdCount++;
        }
    }

    public IInteractiveObject GetCoin(int index) => _snowflakes[index];
}
