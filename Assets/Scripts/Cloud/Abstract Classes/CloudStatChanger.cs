using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Cloud), typeof(CloudScanner))]
public abstract class CloudStatChanger : MonoBehaviour
{
    [SerializeField] private LevelGenerator _generator;

    private CloudScanner _scanner;

    private float _lowerValue;
    private float _upperValue;

    private float _currentValue;
    private float _divisionValue;
    private float _divisionsNumber;

    private float _fillingSpeed;

    public float LowerValue => _lowerValue;

    public float CurrentValue => _currentValue;

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
        _generator.Launched += SetDefaultValue;
        _scanner.FoundWater += IncreaseCurrentValue;
        _scanner.FoundInteractionObject += DecreaseCurrentValue;
    }

    private void OnDisable()
    {
        _generator.Launched -= SetDefaultValue;
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

    protected void InitializeValues(float upperValueNumber, float lowerValueNumber)
    {
        _upperValue = upperValueNumber;
        _lowerValue = lowerValueNumber;

        _divisionValue = (_upperValue - _lowerValue) / _divisionsNumber;
        _currentValue = _upperValue;
    }

    private void SetDefaultValue(uint currentLevel)
    {
        _currentValue = _upperValue;
    }
}