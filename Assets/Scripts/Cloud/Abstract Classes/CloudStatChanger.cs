using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Cloud), typeof(CloudScanner))]
public abstract class CloudStatChanger : MonoBehaviour
{
    private CloudScanner _scanner;

    private float _lowerValue;
    private float _upperValue;

    private float _currentValue;
    private float _divisionValue;
    private float _divisionsNumber;

    private float _fillingSpeed;

    private UnityAction _changedValue;

    public event UnityAction ChangedValue
    {
        add => _changedValue += value;
        remove => _changedValue -= value;
    }

    public float LowerValue => _lowerValue;

    public float CurrentValue => _currentValue;

    public CloudScanner Scanner => _scanner;

    private void Awake()
    {
        _scanner = GetComponent<CloudScanner>();
        _fillingSpeed = 60f;
    }

    private void OnEnable()
    {
        _scanner.FoundWater += IncreaseCurrentValue;
        _scanner.FoundInteractionObject += DecreaseCurrentValue;
    }

    private void OnDisable()
    {
        _scanner.FoundWater -= IncreaseCurrentValue;
        _scanner.FoundInteractionObject -= DecreaseCurrentValue;
    }

    protected virtual void DecreaseCurrentValue()
    {
        _currentValue -= _divisionValue * Time.deltaTime * _fillingSpeed;
        _changedValue?.Invoke();

        if (_currentValue < _lowerValue)
            _currentValue = _lowerValue;
    }

    protected virtual void IncreaseCurrentValue()
    {
        if (_currentValue < _upperValue)
        {
            _currentValue += _divisionValue * Time.deltaTime * _fillingSpeed;
            _changedValue?.Invoke();
        }

        if (_currentValue > _upperValue)
            _currentValue = _upperValue;
    }

    protected void InitializeValues(float upperValueNumber, float lowerValueNumber)
    {
        _upperValue = upperValueNumber;
        _lowerValue = lowerValueNumber;

        _divisionsNumber = GetDivisionsNumber();
        _divisionValue = (_upperValue - _lowerValue) / _divisionsNumber;
        _currentValue = _upperValue;
    }

    private float GetDivisionsNumber()
    {
        float levelCoefficient = 100;

        return levelCoefficient;
    }
}