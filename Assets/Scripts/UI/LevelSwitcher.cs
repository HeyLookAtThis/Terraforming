using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private LevelBuilder _levelBuilder;
    [SerializeField] private PanelsSwither _panelsSwither;

    private LevelCounter _counter;

    private void Awake()
    {
        _counter = _levelBuilder.Counter;
    }

    private void OnEnable()
    {
        _nextLevelButton.onClick.AddListener(OnSetNextLevel);
        _restartButton.onClick.AddListener(OnRestartLevel);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(OnSetNextLevel);
        _restartButton.onClick.RemoveListener(OnRestartLevel);
    }


    private void OnSetNextLevel()
    {
        _counter.SetNextLevel();
        _levelBuilder.Clear();
        _levelBuilder.Run();
        _panelsSwither.OnTurnOnGamePanel();
    }

    private void OnRestartLevel()
    {
        _levelBuilder.Clear();
        _levelBuilder.Run();
        _panelsSwither.OnTurnOnGamePanel();
    }
}
