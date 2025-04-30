using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private PanelsSwitcher _panelSwitcher;
    [SerializeField] private GamePanel _gamePanel;

    public override void InstallBindings()
    {
        BindPanelSwitcher();
        BindGamePanel();
    }

    private void BindPanelSwitcher() => Container.BindInterfacesAndSelfTo<PanelsSwitcher>().FromInstance(_panelSwitcher).AsSingle();
    private void BindGamePanel() => Container.BindInterfacesAndSelfTo<GamePanel>().FromInstance(_gamePanel).AsSingle();
}
