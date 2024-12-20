public class LevelCounter
{
    private LevelCounterConfig _config;

    private int _firstLevel;
    private int _lastLevel;
    private int _currentLevel;

    public LevelCounter(LevelCounterConfig config)
    {
        _config = config;

        _firstLevel = _currentLevel = config.FirstLevelNumber;
        _lastLevel = config.LastLevelNumber;
    }

    public int CurrentLevel => _currentLevel;

    public void SetNextLevel()
    {
        if(_currentLevel < _lastLevel)
            _currentLevel++;
    }

    public void SetFirstLevelLevel()
    {
        _currentLevel = _firstLevel;
    }
}
