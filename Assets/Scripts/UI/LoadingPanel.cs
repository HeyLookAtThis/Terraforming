using UnityEngine;
using Zenject;

public class LoadingPanel : MonoBehaviour, IPanel, IGameTimer
{
    [SerializeField] private LoadingBar _bar;

    private IPanelSwitcher _switcher;

    public float PlayingTimeScale => 1.0f;
    public float PausingTimeScale => 0.0f;

    private void OnEnable()
    {
        StartGame();
        _bar.Filled += OnSwitchToGamePanel;
    }

    private void OnDisable()
    {
        _bar.Filled -= OnSwitchToGamePanel;
        StopGame();
    }

    [Inject]
    private void Construct(IPanelSwitcher switcher) => _switcher = switcher;

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    public void StartGame() => Time.timeScale = PlayingTimeScale;
    public void StopGame() => Time.timeScale = PausingTimeScale;

    private void OnSwitchToGamePanel() => _switcher.SwitchPanel<GamePanel>();
}
