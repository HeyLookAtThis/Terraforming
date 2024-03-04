using UnityEngine;
using UnityEngine.Events;

public class Ground : MonoBehaviour
{
    private UnityAction _temperatureChanged;
    private UnityAction _temperatureSet;

    public event UnityAction TemperatureChanged
    {
        add => _temperatureChanged += value;
        remove => _temperatureChanged -= value;
    }

    public event UnityAction TemperatureSet
    {
        add => _temperatureSet += value;
        remove => _temperatureSet -= value;
    }

    public float StartingTemperature { get; private set; }

    public float EndingTemperature { get; private set; }

    public float CurrentTemperature { get; private set; }

    public void InitializeTemperature(float volcanoTemperature, uint currentLevel)
    {
        StartingTemperature = 0;
        CurrentTemperature = StartingTemperature;
        EndingTemperature = volcanoTemperature * currentLevel;

        _temperatureSet?.Invoke();
    }

    public void AddTemperature(float temperature)
    {
        CurrentTemperature += temperature;
        _temperatureChanged?.Invoke();
    }
}