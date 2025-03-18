using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private Terrain _terrain;
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private LevelBuilder _levelBuilder;
    [SerializeField] private MainFactoryConfig _factoryConfig;

    public override void InstallBindings()
    {
        BindTerrain();
        BindLevelConfig();
        BindLevelBoundariesMarker();
        BindGrassPainter();
        BindFactoryConfig();
        BindLevelBuilder();
    }

    private void BindFactoryConfig() => Container.Bind<MainFactoryConfig>().FromInstance(_factoryConfig).AsSingle();
    private void BindLevelBuilder() => Container.BindInterfacesAndSelfTo<LevelBuilder>().FromInstance(_levelBuilder).AsSingle();
    private void BindGrassPainter() => Container.Bind<GrassPainter>().AsSingle();
    private void BindTerrain() => Container.Bind<Terrain>().FromInstance(_terrain).AsSingle();
    private void BindLevelBoundariesMarker() => Container.Bind<LevelBordersMarker>().AsSingle();
    private void BindLevelConfig() => Container.Bind<LevelConfig>().FromInstance(_levelConfig).AsSingle();
}
