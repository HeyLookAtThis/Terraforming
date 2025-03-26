using UnityEngine.Events;

public class LevelCounter
{
    private int _firstLevel;
    private int _lastLevel;
    private int _currentLevel;

    private UnityAction _setNextLevel;

    public LevelCounter(LevelCounterConfig config)
    {
        _firstLevel = _currentLevel = config.FirstLevelNumber;
        _lastLevel = config.LastLevelNumber;
    }

    public event UnityAction SetNextLevel
    {
        add => _setNextLevel += value;
        remove => _setNextLevel -= value;
    }

    public bool IsFirstLevel => _currentLevel == _firstLevel;
    public int CurrentLevel => _currentLevel;

    public void SetNext()
    {
        if(_currentLevel < _lastLevel)
        {
            _currentLevel++;
            _setNextLevel?.Invoke();
        }
    }

    public void SetFirstLevel()
    {
        _currentLevel = _firstLevel;
    }
}
