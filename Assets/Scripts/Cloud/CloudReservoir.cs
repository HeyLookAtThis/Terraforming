using UnityEngine.Events;

public class CloudReservoir : CloudStatChanger
{
    private UnityAction _waterIsOver;

    public event UnityAction WaterIsOver
    {
        add => _waterIsOver += value;
        remove => _waterIsOver -= value;
    }

    public bool HaveWater => CurrentValue > LowerValue;

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
}