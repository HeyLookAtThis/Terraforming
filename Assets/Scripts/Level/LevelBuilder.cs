using System;
using UnityEngine;
using Zenject;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    private LevelConfig _config;
    private LevelCounter _counter;

    private MainFactory _mainFactory;
    private MainSpawner _mainSpawner;

    private Atmosphere _atmosphere;
    private GrassPainter _grassPainter;

    private Character _character;
    private Cloud _cloud;

    public MainFactory MainFactory => _mainFactory;
    public Atmosphere Atmosphere => _atmosphere;
    public LevelCounter Counter => _counter;

    private void OnEnable()
    {
        MainFactory.Volcanoes.AddedVolcano += _atmosphere.OnIncreaseMaxTemperature;
    }

    private void OnDisable()
    {
        MainFactory.Volcanoes.AddedVolcano -= _atmosphere.OnIncreaseMaxTemperature;
    }

    [Inject]
    private void Construnct(Terrain terrain, MainFactoryConfig factoryConfig, LevelConfig levelConfig, LevelBordersMarker levelBoundariesMarker, GrassPainter grassPainter, Character character, Cloud cloud)
    {
        _config = levelConfig;
        _counter = new LevelCounter(_config.CounterConfig);
        _grassPainter = grassPainter;

        _mainFactory = new MainFactory(factoryConfig, _counter, _grassPainter);
        _mainSpawner = new MainSpawner(_mainFactory, levelBoundariesMarker, _counter);

        _atmosphere = new Atmosphere(_config.AtmosphereConfig, _mainFactory.Volcanoes.Storage.Count);

        _character = character;
        _cloud = cloud;
    }

    public void OnStartLevel()
    {
        Clear();
        Run();
    }

    private void Run()
    {
        _mainFactory.Run();
        _mainSpawner.Run();

        SubscribeAtmosphereToAllVolcanoes();
    }

    private void Clear()
    {
        UnsubscribeAtmosphereToAllVolcanoes();
        _mainFactory.Clear();

        _grassPainter.ClearMap();
        SetPlayerPosition();
        _atmosphere.ResetTemperature();
    }

    private void SetPlayerPosition()
    {
        _character.Transform.position = _spawnPoint.position;
        _cloud.transform.position = _spawnPoint.position;
    }

    private void SubscribeAtmosphereToAllVolcanoes()
    {
        for (int i = 0; i < MainFactory.Volcanoes.Storage.Count; i++)
            MainFactory.Volcanoes.Storage.GetVolcano(i).Heating += _atmosphere.IncreaseTemperature;
    }

    private void UnsubscribeAtmosphereToAllVolcanoes()
    {
        for (int i = 0; i < MainFactory.Volcanoes.Storage.Count; i++)
            MainFactory.Volcanoes.Storage.GetVolcano(i).Heating -= _atmosphere.IncreaseTemperature;
    }

}
