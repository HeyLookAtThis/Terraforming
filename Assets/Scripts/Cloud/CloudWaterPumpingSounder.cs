using UnityEngine;

public class CloudWaterPumpingSounder : CloudSounder
{
    [SerializeField] private CloudReservoir _reservoir;

    private float _currentValue;

    private void OnEnable()
    {
        _reservoir.ChangedValue += Run;
    }

    private void OnDisable()
    {
        _reservoir.ChangedValue -= Run;
    }

    protected override void Run()
    {
        if (_currentValue < _reservoir.CurrentValue)
            base.Run();

        _currentValue = _reservoir.CurrentValue;
    }
}
