using UnityEngine;
using Zenject;

public class Panel : MonoBehaviour, IPanel
{
    protected IPanelSwitcher PanelSwitcher { get; private set; }

    public void Hide() => gameObject.SetActive(false);
    public void Show() => gameObject.SetActive(true);

    [Inject]
    private void Construct(IPanelSwitcher switcher) => PanelSwitcher = switcher;
}
