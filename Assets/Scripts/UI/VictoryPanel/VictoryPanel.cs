using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class VictoryPanel : Panel
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _nextLevelButton;

    private LevelCounter _levelCounter;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRunLoadingPanel);
        _nextLevelButton.onClick.AddListener(OnStartLoadNextLevel);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRunLoadingPanel);
        _nextLevelButton.onClick.RemoveListener(OnStartLoadNextLevel);
    }

    [Inject]
    private void Construct(LevelBuilder levelBuilder)
    {
        _levelCounter = levelBuilder.Counter;
    }

    private void OnRunLoadingPanel() => PanelSwitcher.SwitchPanel<LoadingPanel>();

    private void OnStartLoadNextLevel()
    {
        _levelCounter.SetNext();
        PanelSwitcher.SwitchPanel<LoadingPanel>();
    }
}
