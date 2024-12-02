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

    public bool HaveWater => _wateringTime > 0;

    protected override void OnIncreaseValue()
    {
        base.OnIncreaseValue();

        if (_currentWateringTime < _wateringTime)
            _currentWateringTime += _fillingSpeed * Time.deltaTime;
    }

    protected override void OnDecreaseValue()
    {
        base.OnDecreaseValue();

        if (IsWorking == false)
            return;

        _currentWateringTime -= Time.deltaTime;

        if (_currentWateringTime <= 0)
        {
            _waterIsOver?.Invoke();
            _currentWateringTime = 0;
        }
    }
}
