using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSwitcher : MonoBehaviour
{
    [SerializeField] private List<TutorialPanel> _panels;
    [SerializeField] private Button _nextButton;

    private int _currentPanelIndex;

    private void OnEnable()
    {
        _currentPanelIndex = 0;
        _panels[_currentPanelIndex].Show();

        _nextButton.onClick.AddListener(OnShowPanelWithCurrntIndex);
    }

    private void OnDisable()
    {
        _nextButton.onClick.RemoveListener(OnShowPanelWithCurrntIndex);
    }

    private void OnShowPanelWithCurrntIndex()
    {
        _panels[_currentPanelIndex].Hide();
        _currentPanelIndex++;
        
        if(_currentPanelIndex < _panels.Count)
            _panels[_currentPanelIndex].Show();
        else
            gameObject.SetActive(false);
    }
}
