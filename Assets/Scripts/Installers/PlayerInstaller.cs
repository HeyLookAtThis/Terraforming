using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private CameraDirectionIndicator _cameraDirectionIndicator;
    [SerializeField] private Character _prefab;
    [SerializeField] private Transform _spawnPoint;

    public override void InstallBindings()
    {
        BindDirectionIndicator();
        BindPlayer();
    }

    private void BindDirectionIndicator() => Container.Bind<CameraDirectionIndicator>().FromInstance(_cameraDirectionIndicator).AsSingle();

    private void BindPlayer()
    {
        Character caracter = Container.InstantiatePrefabForComponent<Character>(_prefab, _spawnPoint.position, Quaternion.identity, null);
        Container.BindInterfacesAndSelfTo<Character>().FromInstance(caracter).AsSingle();
    }
}
