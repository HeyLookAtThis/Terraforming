using UnityEngine;
using UnityEngine.Events;

public class LevelCounter : MonoBehaviour
{
    [SerializeField] private uint _finishLevelNumber;
    [SerializeField] private uint _startLevelNumber;
    [SerializeField] private WinPanel _winPanel;

    private uint _currentLevel;

    private UnityAction _numberChanged;

    public event UnityAction NumberChanged
    {
        add => _numberChanged += value;
        remove => _numberChanged -= value;
    }

    public uint CurrentLevel => _currentLevel;

    private void Awake()
    {
        if(_startLevelNumber == 0) 
            _startLevelNumber = 1;

        _currentLevel = _startLevelNumber;
    }

    private void OnEnable()
    {
        _winPanel.ContinueButton.AddListener(SetNextLevel);
    }

    private void OnDisable()
    {
        _winPanel.ContinueButton.RemoveListener(SetNextLevel);
    }

    public void SetNextLevel()
    {
        if (_currentLevel < _finishLevelNumber)
        {
            _currentLevel++;
            _numberChanged?.Invoke();
        }
    }
}