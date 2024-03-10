using UnityEngine;
using UnityEngine.Events;

public class CloudResizer : CloudStatChanger
{
    [SerializeField] private GameObject _cloudModel;

    private float _nextValue;

    private UnityAction<float> _changedValue;

    public event UnityAction<float> ChangedValue
    {
        add => _changedValue += value;
        remove => _changedValue -= value;
    }

    private void Update()
    {
        if (_nextValue != CurrentValue)
        {
            _cloudModel.transform.localScale = new Vector3(CurrentValue, CurrentValue, CurrentValue);
            _nextValue = CurrentValue;
        }
    }

    protected override void DecreaseCurrentValue()
    {
        float pastValue = CurrentValue;

        if (CurrentValue > LowerValue)
        {
            base.DecreaseCurrentValue();
            _changedValue?.Invoke(CurrentValue);
        }
    }

    protected override void IncreaseCurrentValue()
    {
        float pastValue = CurrentValue;
        base.IncreaseCurrentValue();
        _changedValue?.Invoke(CurrentValue);
    }
}