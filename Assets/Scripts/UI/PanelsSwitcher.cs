using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelsSwitcher : MonoBehaviour, IPanelSwitcher
{
    [SerializeField] private PreviewPanel _previewPanel;
    [SerializeField] private LoadingPanel _loadingPanel;
    [SerializeField] private GamePanel _gamePanel;
    [SerializeField] private VictoryPanel _winPanel;
    [SerializeField] private GameOverPanel _losingPanel;

    private List<IPanel> _panels;
    private IPanel _currentPanel;

    private void Awake()
    {
        _panels = new List<IPanel> { _gamePanel, _winPanel, _losingPanel, _loadingPanel, _previewPanel };
        HideAll();
        SwitchPanel<PreviewPanel>();
    }

    public void SwitchPanel<T>() where T : IPanel
    {
        IPanel panel = _panels.FirstOrDefault(panel => panel is T);

        _currentPanel?.Hide();
        _currentPanel = panel;
        _currentPanel.Show();
    }

    private void HideAll()
    {
        foreach (var panel in _panels)
            panel.Hide();
    }
}
