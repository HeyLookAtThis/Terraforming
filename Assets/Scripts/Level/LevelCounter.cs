using UnityEngine;

public class LevelCounter : MonoBehaviour
{
    [SerializeField] private uint _finishLevelNumber;
    [SerializeField] private uint _startLevelNumber;

    private uint _currentLevel;

    public uint CurrentLevel => _currentLevel;

    private void Awake()
    {
        if(_startLevelNumber == 0) 
            _startLevelNumber = 1;

        _currentLevel = _startLevelNumber;
    }

    public void SetNextLevel()
    {
        if (_currentLevel <= _finishLevelNumber)
            _currentLevel++;
    }
}