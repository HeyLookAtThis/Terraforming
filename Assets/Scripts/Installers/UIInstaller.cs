using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private PanelsSwitcher _stateSwitcher;

    public override void InstallBindings()
    {
        BindStateSwitcher();
    }

    private void BindStateSwitcher() => Container.BindInterfacesAndSelfTo<PanelsSwitcher>().FromInstance(_stateSwitcher).AsSingle();
}
