using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameOverPanel : MonoBehaviour, IPanel
{
    [SerializeField] private Button _restartButton;

    private IPanelSwitcher _switcher;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRunLoadingPanel);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRunLoadingPanel);
    }

    [Inject]
    private void Construct(IPanelSwitcher panelSwitcher) => _switcher = panelSwitcher;

    public void Hide() => gameObject.SetActive(false);
    public void Show() => gameObject.SetActive(true);

    private void OnRunLoadingPanel() => _switcher.SwitchPanel<LoadingPanel>();
}
