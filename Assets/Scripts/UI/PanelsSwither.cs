using UnityEngine;

public class PanelsSwither : MonoBehaviour
{
    [SerializeField] private Panel _gamePanel;
    [SerializeField] private Panel _winPanel;
    [SerializeField] private Panel _losingPanel;

    private Panel[] _panels;

    private void Awake()
    {
        _panels = new Panel[] { _gamePanel, _winPanel, _losingPanel };
    }

    public void OnTurnOnGamePanel()
    {
        TurnOffAllPanels();
        _gamePanel.gameObject.SetActive(true);
    }

    public void OnTurnOnWinPanel()
    {
        TurnOffAllPanels();
        _winPanel.gameObject.SetActive(true);
    }

    public void OnTurnOnLosingPanel()
    {
        TurnOffAllPanels();
        _losingPanel.gameObject.SetActive(true);
    }

    private void TurnOffAllPanels()
    {
        foreach (var panel in _panels)
            panel.gameObject.SetActive(false);
    }
}
