using System.Collections.Generic;
using UnityEngine;

public class VolcanoFactory
{
    private VolcanoFactoryConfig _config;
    private List<Volcano> _volcanoes;

    private LevelCounter _levelCounter;

    public VolcanoFactory(VolcanoFactoryConfig config, LevelCounter levelCounter)
    {
        _config = config;
        _levelCounter = levelCounter;

        _volcanoes = new List<Volcano>();
    }

    public int Count => _volcanoes.Count;

    public void Run()
    {
        int createdCount = 0;
        GameObject storage = new GameObject("VolcanoStorage");

        while (createdCount < _levelCounter.CurrentLevel)
        {
            Volcano volcano = Object.Instantiate(_config.Prefab, storage.transform);
            volcano.BeginHeatGround();
            _volcanoes.Add(volcano);
            createdCount++;
        }
    }

    public IInteractiveObject GetVolcano(int index) => _volcanoes[index];
}
