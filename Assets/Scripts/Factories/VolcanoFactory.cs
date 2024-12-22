using UnityEngine;
using UnityEngine.Events;

public class VolcanoFactory
{
    private VolcanoFactoryConfig _config;

    private LevelCounter _levelCounter;
    private VolcanoStorage _storage;

    private UnityAction _createdVolcano;

    public VolcanoFactory(VolcanoFactoryConfig config, LevelCounter levelCounter, VolcanoStorage storage)
    {
        _config = config;
        _levelCounter = levelCounter;
        _storage = storage;
    }

    public event UnityAction CreatedVolcano
    {
        add => _createdVolcano += value;
        remove => _createdVolcano -= value;
    }

    public void Run()
    {
        while (_storage.Count < _levelCounter.CurrentLevel)
        {
            Volcano volcano = Object.Instantiate(_config.Prefab, _storage.Transform);
            _storage.Add(volcano);
            _createdVolcano?.Invoke();
        }
    }
}
