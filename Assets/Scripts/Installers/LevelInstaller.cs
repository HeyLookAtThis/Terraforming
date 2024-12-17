using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private Terrain _terrain;
    [SerializeField] private MainFactoryConfig _factoryConfig;
    [SerializeField] private LevelBuilder _levelBuilder;
    [SerializeField] private LevelConfig _levelConfig;

    public override void InstallBindings()
    {
        BindTerrain();
        BindLevelBoundariesMarker();
        BindGrassPainter();
        BindFactoryConfig();
        BindLevelConfig();
        BindLevelBuilder();
    }

    private void BindGrassPainter() => Container.Bind<GrassPainter>().AsSingle();
    private void BindTerrain() => Container.Bind<Terrain>().FromInstance(_terrain).AsSingle();
    private void BindLevelBoundariesMarker() => Container.Bind<LevelBordersMarker>().AsSingle();
    private void BindFactoryConfig() => Container.Bind<MainFactoryConfig>().FromInstance(_factoryConfig).AsSingle();
    private void BindLevelConfig() => Container.Bind<LevelConfig>().FromInstance(_levelConfig).AsSingle();
    private void BindLevelBuilder() => Container.BindInterfacesAndSelfTo<LevelBuilder>().FromInstance(_levelBuilder).AsSingle();
}
