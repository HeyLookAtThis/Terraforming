public class LevelCounter
{
    private int _firstLevel;
    private int _lastLevel;
    private int _currentLevel;

    public bool IsFirstLevel => _currentLevel == _firstLevel;

    public LevelCounter(LevelCounterConfig config)
    {
        _firstLevel = _currentLevel = config.FirstLevelNumber;
        _lastLevel = config.LastLevelNumber;
    }

    public int CurrentLevel => _currentLevel;

    public void SetNextLevel()
    {
        if(_currentLevel < _lastLevel)
            _currentLevel++;
    }

    public void SetFirstLevel()
    {
        _currentLevel = _firstLevel;
    }
}
