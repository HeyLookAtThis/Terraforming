using UnityEngine.Events;

public class Atmosphere
{
    private AtmosphereConfig _config;

    private float _maxTemperature;
    private float _minTemperature;
    private float _currentTemperature;

    private UnityAction _reachedMaxTemperature;
    private UnityAction<float> _temperatureChanged;
    private UnityAction _maxTemperatureChanged;

    public Atmosphere(AtmosphereConfig config)
    {
        _config = config;
        _minTemperature = _currentTemperature = 0;
    }

    public event UnityAction ReachedMaxTemperature
    {
        add => _reachedMaxTemperature += value;
        remove => _reachedMaxTemperature -= value;
    }

    public event UnityAction<float> TemperatureChanged
    {
        add => _temperatureChanged += value;
        remove => _temperatureChanged -= value;
    }

    public event UnityAction MaxTemperatureChanged
    {
        add => _maxTemperatureChanged += value;
        remove => _maxTemperatureChanged -= value;
    }
    
    public float MaxTemperature => _maxTemperature;
    public float MinTemperature => _minTemperature;

    public void InitializeMaxTemperature(int volcanoesCount)
    {
        _maxTemperature = _config.TimeToReachMaxTemperature * volcanoesCount;
        _maxTemperatureChanged?.Invoke();
    }

    public void IncreaseTemperature(float temperature)
    {
        if (_currentTemperature < _maxTemperature)
        {
            _currentTemperature += temperature;
            _temperatureChanged?.Invoke(_currentTemperature);
        }
        else
        {
            _currentTemperature = _maxTemperature;
            _reachedMaxTemperature?.Invoke();
        }
    }

    public void ResetTemperature()
    {
        _currentTemperature = _minTemperature;
        _maxTemperature = _currentTemperature;
    }
}
