using UnityEngine;
using UnityEngine.Events;

public class Reservoir
{
    private float _wateringTime;
    private float _currentWateringTime;

    private UnityAction _waterIsOver;

    public Reservoir(float wateringTime)
    {
        _wateringTime = wateringTime;
    }

    public event UnityAction WaterIsOver
    {
        add => _waterIsOver += value;
        remove => _waterIsOver -= value;
    }

    public void Update()
    {
        _currentWateringTime -= Time.deltaTime;

        if (_currentWateringTime <= 0)
        {
            _waterIsOver?.Invoke();
            _currentWateringTime = _wateringTime;
        }
    }
}
