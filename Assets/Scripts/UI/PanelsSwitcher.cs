using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelsSwitcher : MonoBehaviour, IPanelSwitcher
{
    [SerializeField] private List<Panel> _panels;

    private IPanel _currentPanel;

    public void Initialize()
    {
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
