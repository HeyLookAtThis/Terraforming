using UnityEngine;
using Zenject;

public class LoadingPanel : MonoBehaviour, IPanel
{
    [SerializeField] private LoadingBar _bar;

    private IPanelSwitcher _switcher;

    private void OnEnable() => _bar.Filled += OnSwitchToGamePanel;

    private void OnDisable() => _bar.Filled -= OnSwitchToGamePanel;

    [Inject]
    private void Construct(IPanelSwitcher switcher) => _switcher = switcher;

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    private void OnSwitchToGamePanel() => _switcher.SwitchPanel<GamePanel>();
}
