using UnityEngine;
using Zenject;

public class CloudInstaller : MonoInstaller
{
    [SerializeField] private Terrain _terrain;
    [SerializeField] private Cloud _prefab;

    public override void InstallBindings()
    {
        BindTerrain();
        BindCloud();
    }

    private void BindTerrain() => Container.Bind<Terrain>().FromInstance(_terrain).AsSingle();

    private void BindCloud()
    {
        Cloud cloud = Container.InstantiatePrefabForComponent<Cloud>(_prefab);
        Container.BindInterfacesAndSelfTo<Cloud>().FromInstance(cloud).AsSingle();
    }
}
