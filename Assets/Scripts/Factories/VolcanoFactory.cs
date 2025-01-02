using UnityEngine;
using UnityEngine.Events;

public class VolcanoFactory
{
    private VolcanoFactoryConfig _config;

    private LevelCounter _levelCounter;
    private VolcanoStorage _storage;

    private UnityAction _finished;

    public VolcanoFactory(VolcanoFactoryConfig config, LevelCounter levelCounter, VolcanoStorage storage)
    {
        _config = config;
        _levelCounter = levelCounter;
        _storage = storage;
    }

    public event UnityAction Finished
    {
        add => _finished += value;
        remove => _finished -= value;
    }

    public void Run()
    {
        while (_storage.Count < _levelCounter.CurrentLevel)
        {
            Volcano volcano = Object.Instantiate(_config.Prefab, _storage.Transform);
            _storage.Add(volcano);
            _storage.SubscribeOnVolcano(volcano);
        }

        _finished?.Invoke();
    }
}
