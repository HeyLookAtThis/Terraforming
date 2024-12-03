using UnityEngine;
using Zenject;

public class LevelBuilderInstaller : MonoInstaller
{
    [SerializeField] private Terrain _terrain;
    [SerializeField] private MainFactoryConfig _factoryConfig;
    [SerializeField] private LevelBuilder _levelBuilder;
    [SerializeField] private LevelConfig _levelConfig;

    public override void InstallBindings()
    {
        BindTerrain();
        BindFactoryConfig();
        BindLevelConfig();
        BindLevelBoundariesMarker();
        BindLevelBuilder();
    }

    private void BindTerrain() => Container.Bind<Terrain>().FromInstance(_terrain).AsSingle();
    private void BindFactoryConfig() => Container.Bind<MainFactoryConfig>().FromInstance(_factoryConfig).AsSingle();
    private void BindLevelConfig() => Container.Bind<LevelConfig>().FromInstance(_levelConfig).AsSingle();
    private void BindLevelBoundariesMarker() => Container.Bind<LevelBoundariesMarker>().AsSingle();
    private void BindLevelBuilder() => Container.BindInterfacesAndSelfTo<LevelBuilder>().FromInstance(_levelBuilder).AsSingle();
}
