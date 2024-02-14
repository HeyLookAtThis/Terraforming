using UnityEngine;
using UnityEngine.Events;

public class CloudReservoir : CloudStatChanger
{
    private UnityAction _waterIsOver;
    private UnityAction _filledUp;

    public event UnityAction WaterIsOver
    {
        add => _waterIsOver += value;
        remove => _waterIsOver -= value;
    }

    public event UnityAction FilledUp
    {
        add => _filledUp += value;
        remove => _filledUp -= value;
    }

    public bool HaveWater => CurrentValue > LowerValue;

    private void Start()
    {
        float upperValue = 1f;
        float lowerValue = 0f;

        InitializeValues(upperValue, lowerValue);
    }

    protected override void DecreaseCurrentValue()
    {
        if (HaveWater)
        {
            base.DecreaseCurrentValue();
        }
        else
        {
            if (Scanner.IsContainsWater() == false)
                _waterIsOver?.Invoke();
        }
    }

    protected override void IncreaseCurrentValue()
    {
        base.IncreaseCurrentValue();

        if (CurrentValue >= UpperValue)
            _filledUp?.Invoke();
    }
}