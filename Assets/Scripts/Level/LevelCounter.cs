using UnityEngine;

public class LevelCounter : MonoBehaviour
{
    //[SerializeField] private LevelStarter _levelStarter;
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

    //private void OnEnable()
    //{
    //    _levelStarter.Beginning += SetNextLevel;
    //}

    //private void OnDisable()
    //{
    //    _levelStarter.Beginning -= SetNextLevel;
    //}

    public void SetNextLevel()
    {
        if (_currentLevel <= _finishLevelNumber)
            _currentLevel++;
    }
}