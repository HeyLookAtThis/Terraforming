using UnityEngine;
using Zenject;

public class CloudInstaller : MonoInstaller
{
    [SerializeField] private Cloud _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GamePanel _gamePanel;


    public override void InstallBindings() => BindCloud();

    private void BindCloud()
    {
        Cloud cloud = Container.InstantiatePrefabForComponent<Cloud>(_prefab, _spawnPoint.position, Quaternion.identity, null);
        cloud.View.InitializeObjectSounder(_gamePanel);
        Container.BindInterfacesAndSelfTo<Cloud>().FromInstance(cloud).AsSingle();
    }
}
