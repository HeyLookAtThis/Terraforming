using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Character _prefab;
    [SerializeField] private Transform _spawnPoint;

    public override void InstallBindings()
    {
        BindPlayer();
    }

    private void BindPlayer()
    {
        Character caracter = Container.InstantiatePrefabForComponent<Character>(_prefab, _spawnPoint.position, Quaternion.identity, null);
        Container.BindInterfacesAndSelfTo<Character>().FromInstance(caracter).AsSingle();
    }
}
