using UnityEngine;
using UnityEngine.Events;

public class Ground : MonoBehaviour
{
    private UnityAction _temperatureChanged;
    private UnityAction _overheated;

    public event UnityAction TemperatureChanged
    {
        add => _temperatureChanged += value;
        remove => _temperatureChanged -= value;
    }

    public event UnityAction Overheated
    {
        add => _overheated += value;
        remove => _overheated -= value;
    }

    public float StartingTemperature { get; private set; }

    public float EndingTemperature { get; private set; }

    public float CurrentTemperature { get; private set; }

    public void InitializeTemperature(float volcanoTemperature, uint currentLevel)
    {
        StartingTemperature = 0;
        CurrentTemperature = StartingTemperature;
        EndingTemperature = volcanoTemperature * currentLevel;
    }

    public void AddTemperature(float temperature)
    {
        if(CurrentTemperature < EndingTemperature)
        {
            CurrentTemperature += temperature;
            _temperatureChanged?.Invoke();
        }
        else
        {
            _overheated?.Invoke();
        }
    }
}