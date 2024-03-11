using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LevelCounter))]
public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private EndGamePanel _endGamePanel;
    [SerializeField] private TitlePanel _titlePanel;

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
        _endGamePanel.RestartAction += OnLaunch;
        _titlePanel.Clicked += OnLaunch;
    }

    private void OnDisable()
    {
        _endGamePanel.RestartAction -= OnLaunch;
        _titlePanel.Clicked -= OnLaunch;
    }

    private void OnLaunch()
    {
        _launched?.Invoke(_levelCounter.CurrentLevel);
    }
}
