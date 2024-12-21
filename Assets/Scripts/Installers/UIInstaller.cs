using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private PanelsSwitcher _panelSwitcher;

    public override void InstallBindings()
    {
        BindPanelSwitcher();
    }

    private void BindPanelSwitcher() => Container.BindInterfacesAndSelfTo<PanelsSwitcher>().FromInstance(_panelSwitcher).AsSingle();
}
