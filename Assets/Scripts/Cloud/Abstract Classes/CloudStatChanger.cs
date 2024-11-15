using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class CloudStatChanger : MonoBehaviour
{
    [SerializeField] private float _lowerValue;
    [SerializeField] private float _upperValue;

    private CloudScanner _scanner;

    private float _currentValue;
    private float _divisionValue;
    private float _divisionsNumber;

    private float _fillingSpeed;

    public float LowerValue => _lowerValue;

    public float CurrentValue => _currentValue;

    private UnityAction _changedValue;

    public event UnityAction ChangedValue
    {
        add => _changedValue += value;
        remove => _changedValue -= value;
    }

    public CloudScanner Scanner => _scanner;

    public float DivisionsNumber => _divisionsNumber;

    private void Awake()
    {
        _scanner = GetComponent<CloudScanner>();
        _fillingSpeed = 60f;
        _divisionsNumber = 100f;
    }

    private void OnEnable()
    {
        InitializeValues();
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
        _currentValue -= _divisionValue;
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

    private void InitializeValues()
    {
        _divisionValue = (_upperValue - _lowerValue) / _divisionsNumber;
        _currentValue = _upperValue;
    }
}