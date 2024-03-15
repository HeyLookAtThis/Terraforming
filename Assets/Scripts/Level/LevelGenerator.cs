using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LevelCounter))]
public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private TitlePanel _titlePanel;
    [SerializeField] private WinPanel _winPanel;

    private LevelCounter _levelCounter;

    private UnityAction<uint> _launched;

    public event UnityAction<uint> Launched
    {
        add => _launched += value;
        remove => _launched -= value;
    }

    private void Awake()
    {
        _levelCounter = GetComponent<LevelCounter>();
    }

    private void OnEnable()
    {
        _gameOverPanel.RestartAction += OnLaunch;
        _titlePanel.Clicked += OnLaunch;
        _levelCounter.NumberChanged += OnLaunch;
        _winPanel.RestartButtonClicked += OnLaunch;
    }

    private void OnDisable()
    {
        _gameOverPanel.RestartAction -= OnLaunch;
        _titlePanel.Clicked -= OnLaunch;
        _levelCounter.NumberChanged -= OnLaunch;
        _winPanel.RestartButtonClicked -= OnLaunch;
    }

    private void OnLaunch()
    {
        _launched?.Invoke(_levelCounter.CurrentLevel);
    }
}
