using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public class Thermometer : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Coroutine _valueChanger;
    private UnityAction _reachedMaxValue;

    private Atmosphere _atmosphere;

    public event UnityAction ReachedMaxValue
    {
        add => _reachedMaxValue += value;
        remove => _reachedMaxValue -= value;
    }

    private void OnEnable()
    {
        _atmosphere.TemperatureChanged += OnBeginChangeValue;
        _atmosphere.MaxTemperatureChanged += OnSetMaxTemperature;
    }

    private void OnDisable()
    {
        _atmosphere.TemperatureChanged -= OnBeginChangeValue;
        _atmosphere.MaxTemperatureChanged -= OnSetMaxTemperature;
    }

    [Inject]
    private void Construct(LevelBuilder levelBuilder)
    {
        _atmosphere = levelBuilder.Atmosphere;
    }

    public void InitializeValues()
    {
        _slider.minValue = _atmosphere.MinTemperature;
        _slider.maxValue = _atmosphere.MaxTemperature;
        _slider.value = _atmosphere.MinTemperature;
    }

    public void OnSetMaxTemperature() => _slider.maxValue = _atmosphere.MaxTemperature;

    public void OnBeginChangeValue(float temperature)
    {
        if (_valueChanger != null)
            StopCoroutine(_valueChanger);

        _valueChanger = StartCoroutine(ValueChanger(temperature));
    }

    private IEnumerator ValueChanger(float temperature)
    {
        float seconds = 0.02f;
        var waitTime = new WaitForSeconds(seconds);

        float fillingSpeed = 0.5f;

        while (_slider.value != temperature)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, temperature, fillingSpeed);
            yield return waitTime;
        }

        if (_slider.value == temperature)
        {
            if (_slider.value == _slider.maxValue)
                _reachedMaxValue?.Invoke();

            yield break;
        }
    }
}
