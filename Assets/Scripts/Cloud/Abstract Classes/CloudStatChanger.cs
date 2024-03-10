using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Cloud), typeof(CloudScanner))]
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

    public CloudScanner Scanner => _scanner;

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

        if (_currentValue < _lowerValue)
            _currentValue = _lowerValue;
    }

    protected virtual void IncreaseCurrentValue()
    {
        if (_currentValue < _upperValue)
            _currentValue += _divisionValue * Time.deltaTime * _fillingSpeed;

        if (_currentValue > _upperValue)
            _currentValue = _upperValue;
    }

    private void InitializeValues()
    {
        _divisionValue = (_upperValue - _lowerValue) / _divisionsNumber;
        _currentValue = _upperValue;
    }
}