using UnityEngine;

public class CloudResizer : CloudStatChanger
{
    [SerializeField] private GameObject _cloudModel;

    private float _nextValue;

    private void Start()
    {
        float upperValue = 1f;
        float lowerValue = 0.4f;

        InitializeValues(upperValue, lowerValue);
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
        if (CurrentValue > LowerValue)
            base.DecreaseCurrentValue();
    }
}