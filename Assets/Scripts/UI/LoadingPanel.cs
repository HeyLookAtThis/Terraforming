using UnityEngine;

public class LoadingPanel : Panel, IGameTimer
{
    [SerializeField] private LoadingBar _bar;

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

    public void StartGame() => Time.timeScale = PlayingTimeScale;
    public void StopGame() => Time.timeScale = PausingTimeScale;

    private void OnSwitchToGamePanel() => PanelSwitcher.SwitchPanel<GamePanel>();
}
