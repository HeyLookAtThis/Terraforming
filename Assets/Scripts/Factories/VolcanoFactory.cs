using UnityEngine;
using UnityEngine.Events;

public class VolcanoFactory
{
    private VolcanoFactoryConfig _config;

    private LevelCounter _levelCounter;
    private VolcanoStorage _storage;

    private UnityAction _created;

    public VolcanoFactory(VolcanoFactoryConfig config, LevelCounter levelCounter)
    {
        _config = config;
        _levelCounter = levelCounter;

        string storageName = "VolcanoStorage";
        _storage = new VolcanoStorage(storageName);
    }

    public VolcanoStorage Storage => _storage;

    public event UnityAction Created
    {
        add => _created += value;
        remove => _created -= value;
    }

    public void Run()
    {
        while (_storage.Count < _levelCounter.CurrentLevel)
        {
            Volcano volcano = Object.Instantiate(_config.Prefab, _storage.Transform);
            volcano.BeginHeatGround();
            _storage.Add(volcano);
        }

        _created?.Invoke();
    }
}
