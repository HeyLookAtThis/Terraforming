using UnityEngine;
using Zenject;

public class CloudInstaller : MonoInstaller
{
    [SerializeField] private Cloud _prefab;
    [SerializeField] private Transform _spawnPoint;

    public override void InstallBindings()
    {
        BindCloud();
    }


    private void BindCloud()
    {
        Cloud cloud = Container.InstantiatePrefabForComponent<Cloud>(_prefab, _spawnPoint.position, Quaternion.identity, null);
        Container.BindInterfacesAndSelfTo<Cloud>().FromInstance(cloud).AsSingle();
    }
}
