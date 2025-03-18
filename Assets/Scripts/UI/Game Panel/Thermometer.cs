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
        _atmosphere.ReachedMaxTemperature += OnInvokeReachedMaxValue;
    }

    private void OnDisable()
    {
        _atmosphere.TemperatureChanged -= OnBeginChangeValue;
        _atmosphere.MaxTemperatureChanged -= OnSetMaxTemperature;
        _atmosphere.ReachedMaxTemperature -= OnInvokeReachedMaxValue;
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

    private void OnSetMaxTemperature() => _slider.maxValue = _atmosphere.MaxTemperature;

    private void OnBeginChangeValue(float temperature)
    {
        StopCoroutine();
        _valueChanger = StartCoroutine(ValueChanger(temperature));
    }

    private void OnInvokeReachedMaxValue()
    {
        StopCoroutine();
        _reachedMaxValue?.Invoke();
    }

    private void StopCoroutine()
    {
        if (_valueChanger != null)
            StopCoroutine(_valueChanger);
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
            yield break;
    }
}
