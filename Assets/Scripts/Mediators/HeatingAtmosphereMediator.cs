using UnityEngine;

public class HeatingAtmosphereMediator : MonoBehaviour
{
    [SerializeField] private LevelBuilder _levelBuilder;
    [SerializeField] private Thermometer _thermometer;

    private VolcanoFactory _volcanoFactory;
    private Atmosphere _atmosphere;

    private void Awake() => Initialize();

    private void OnEnable()
    {
        _volcanoFactory.Created += OnInitializeSubjects;
        _atmosphere.TemperatureChanged += _thermometer.OnBeginChangeValue;
    }

    private void OnDisable()
    {
        _volcanoFactory.Created -= OnInitializeSubjects;
        UnsubscribeAtmosphereToAllVolcanoes();
        _atmosphere.TemperatureChanged -= _thermometer.OnBeginChangeValue;
    }

    private void Initialize()
    {
        _volcanoFactory = _levelBuilder.MainFactory.Volcanoes;
        _atmosphere = _levelBuilder.Atmosphere;
    }

    private void OnInitializeSubjects() 
    {
        _atmosphere.InitializeMaxTemperature(_volcanoFactory.Storage.Count);
        _thermometer.Initialize(_atmosphere);

        SubscribeAtmosphereToAllVolcanoes();
    }

    private void SubscribeAtmosphereToAllVolcanoes()
    {
        for (int i = 0; i < _volcanoFactory.Storage.Count; i++)
            _volcanoFactory.Storage.GetVolcano(i).Heating += _atmosphere.IncreaseTemperature;
    }

    private void UnsubscribeAtmosphereToAllVolcanoes()
    {
        for (int i = 0; i < _volcanoFactory.Storage.Count; i++)
            _volcanoFactory.Storage.GetVolcano(i).Heating -= _atmosphere.IncreaseTemperature;
    }
}
