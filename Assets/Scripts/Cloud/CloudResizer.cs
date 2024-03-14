using UnityEngine;
using UnityEngine.Events;

public class CloudResizer : CloudStatChanger
{
    [SerializeField] private GameObject _cloudModel;

    private float _nextValue;

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
        if (CurrentValue > LowerValue)
        {
            base.DecreaseCurrentValue();
        }
    }
}