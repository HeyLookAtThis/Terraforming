using UnityEngine;

public class LoadingPanel : Panel
{
    [SerializeField] private LoadingBar _bar;

    public float PlayingTimeScale => 1.0f;
    public float PausingTimeScale => 0.0f;

    private void OnEnable()
    {
        _bar.Filled += OnSwitchToGamePanel;
    }

    private void OnDisable()
    {
        _bar.Filled -= OnSwitchToGamePanel;
    }

    private void OnSwitchToGamePanel() => PanelSwitcher.SwitchPanel<GamePanel>();
}
