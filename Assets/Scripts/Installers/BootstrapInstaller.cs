using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private Bootstrap _bootstrap;

    public override void InstallBindings()
    {
        BindBootstrap();
    }

    private void BindBootstrap() => Container.BindInterfacesAndSelfTo<Bootstrap>().FromInstance(_bootstrap).AsSingle();
}
