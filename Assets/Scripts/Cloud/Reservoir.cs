using UnityEngine;
using UnityEngine.Events;

public class Reservoir : CloudWaterIndicator
{
    private float _currentWateringTime;
    private float _wateringTime;
    private float _fillingSpeed;

    private UnityAction _waterIsOver;

    public Reservoir(Cloud cloud) : base(cloud)
    {
        _wateringTime = cloud.Config.CloudWateringConfig.WateringTime;
        _currentWateringTime = _wateringTime;
        _fillingSpeed = cloud.Config.CloudUnderChatacterConfig.FillingSpeed;
    }

    public event UnityAction WaterIsOver
    {
        add => _waterIsOver += value;
        remove => _waterIsOver -= value;
    }

    private float WateringTime => _wateringTime;

    protected override void OnIncreaseValue()
    {
        if (_currentWateringTime < WateringTime)
            _currentWateringTime += _fillingSpeed * Time.deltaTime;
    }

    protected override void OnDecreaseValue()
    {
        _currentWateringTime -= Time.deltaTime;

        if (_currentWateringTime <= 0)
        {
            _waterIsOver?.Invoke();
            _currentWateringTime = 0;
        }
    }
}
