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

    public void Run()
    {
        _mainFactory.Run();
        _mainSpawner.Run();
    }

    public void Clear()
    {
        _mainFactory.Clear();
        _grassPainter.ClearMap();
        SetPlayerPosition();
    }

    private void SetPlayerPosition()
    {
        _character.Transform.position = _spawnPoint.position;
        _cloud.transform.position = _spawnPoint.position;
    }
}
