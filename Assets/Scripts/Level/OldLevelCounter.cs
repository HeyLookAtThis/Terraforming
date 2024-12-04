using UnityEngine;
using UnityEngine.Events;

public class OldLevelCounter : MonoBehaviour
{
    [SerializeField] private uint _finishLevelNumber;
    [SerializeField] private uint _startLevelNumber;
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private GameOverPanel _gameOverPanel;

    private uint _currentLevel;
    private uint _previousLevel;

    private UnityAction _numberChanged;

    public event UnityAction NumberChanged
    {
        add => _numberChanged += value;
        remove => _numberChanged -= value;
    }

    public uint CurrentLevel => _currentLevel;

    public uint PreviousLevel => _previousLevel;

    private void Awake()
    {
        if(_startLevelNumber == 0) 
            _startLevelNumber = 1;

        _currentLevel = _startLevelNumber;
    }

    private void OnEnable()
    {
        _winPanel.ContinueButton.AddListener(SetNextLevel);
        _winPanel.RestartButton.AddListener(SetPreviouseLevel);

        _gameOverPanel.RestartButton.AddListener(SetPreviouseLevel);
    }

    private void OnDisable()
    {
        _winPanel.ContinueButton.RemoveListener(SetNextLevel);
        _winPanel.RestartButton.RemoveListener(SetPreviouseLevel);

        _gameOverPanel.RestartButton.RemoveListener(SetPreviouseLevel);
    }

    private void SetNextLevel()
    {
        if (_currentLevel < _finishLevelNumber)
        {
            _previousLevel = _currentLevel;
            _currentLevel++;
            _numberChanged?.Invoke();
        }
    }

    private void SetPreviouseLevel()
    {
        _previousLevel = _currentLevel;
    }
}