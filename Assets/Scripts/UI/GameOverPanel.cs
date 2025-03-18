using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : Panel
{
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRunLoadingPanel);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRunLoadingPanel);
    }

    private void OnRunLoadingPanel() => PanelSwitcher.SwitchPanel<LoadingPanel>();
}
