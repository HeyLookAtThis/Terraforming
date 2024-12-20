using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class VictoryPanel : MonoBehaviour, IPanel
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _nextLevelButton;

    private IPanelSwitcher _switcher;
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
    private void Construct(IPanelSwitcher panelSwitcher, LevelBuilder levelBuilder)
    {
        _switcher = panelSwitcher;
        _levelCounter = levelBuilder.Counter;
    }

    public void Hide() => gameObject.SetActive(false);
    public void Show() => gameObject.SetActive(true);

    private void OnRunLoadingPanel() => _switcher.SwitchPanel<LoadingPanel>();

    private void OnStartLoadNextLevel()
    {
        _levelCounter.SetNextLevel();
        _switcher.SwitchPanel<LoadingPanel>();
    }
}
