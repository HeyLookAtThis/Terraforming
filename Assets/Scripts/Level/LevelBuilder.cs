using UnityEngine;
using Zenject;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    private LevelConfig _config;
    private LevelCounter _counter;

    private MainStorage _mainStorage;
    private MainFactory _mainFactory;
    private MainPlacemaker _mainPlacemaker;

    private Atmosphere _atmosphere;
    private GrassPainter _grassPainter;

    private Character _character;
    private Cloud _cloud;

    public MainStorage MainStorage => _mainStorage;
    public MainFactory MainFactory => _mainFactory;
    public Atmosphere Atmosphere => _atmosphere;
    public LevelCounter Counter => _counter;

    [Inject]
    private void Construct(Terrain terrain, MainFactoryConfig factoryConfig, LevelConfig levelConfig, LevelBordersMarker levelBoundariesMarker, GrassPainter grassPainter, Character character, Cloud cloud)
    {
        _config = levelConfig;
        _counter = new LevelCounter(_config.CounterConfig);
        _grassPainter = grassPainter;

        _mainStorage = new MainStorage();
        _mainFactory = new MainFactory(factoryConfig, _counter, _grassPainter, _mainStorage);
        _mainPlacemaker = new MainPlacemaker(_mainStorage, levelBoundariesMarker, _counter);

        _atmosphere = new Atmosphere(_config.AtmosphereConfig);

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
        SetPlayerPosition();

        _mainFactory.Run();
        _mainPlacemaker.Run();
        _atmosphere.InitializeMaxTemperature(_mainStorage.Volcanoes.Count);

        SubscribeAtmosphereToVolcanoes();
    }

    private void Clear()
    {
        UnsubscribeAtmosphereToVolcanoes();

        _mainStorage.Clear();
        _grassPainter.ClearMap();
        _atmosphere.ResetTemperature();
        _character.LootCounter.ResetValues();
        _cloud.SetDefaultState();
    }

    private void SetPlayerPosition()
    {
        _character.Transform.position = _spawnPoint.position;
        _cloud.transform.position = _spawnPoint.position;
    }

    private void SubscribeAtmosphereToVolcanoes()
    {
        for (int i = 0; i < _mainStorage.Volcanoes.Count; i++)
            _mainStorage.Volcanoes.GetVolcano(i).Heating += _atmosphere.IncreaseTemperature;
    }

    private void UnsubscribeAtmosphereToVolcanoes()
    {
        for (int i = 0; i < _mainStorage.Volcanoes.Count; i++)
            _mainStorage.Volcanoes.GetVolcano(i).Heating -= _atmosphere.IncreaseTemperature;
    }
}
