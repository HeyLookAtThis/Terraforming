using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public class Thermometer : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _percent;

    private Coroutine _valueChanger;
    private UnityAction _reachedMaxValue;

    private Atmosphere _atmosphere;

    private float _stepNumber;

    public event UnityAction ReachedMaxValue
    {
        add => _reachedMaxValue += value;
        remove => _reachedMaxValue -= value;
    }

    private float MaxImageValue => 1f;

    private void OnEnable()
    {
        _atmosphere.TemperatureChanged += OnBeginChangeValue;
        _atmosphere.MaxTemperatureChanged += OnSetStep;
        _atmosphere.ReachedMaxTemperature += OnInvokeReachedMaxValue;
    }

    private void OnDisable()
    {
        _atmosphere.TemperatureChanged -= OnBeginChangeValue;
        _atmosphere.MaxTemperatureChanged -= OnSetStep;
        _atmosphere.ReachedMaxTemperature -= OnInvokeReachedMaxValue;
    }

    [Inject]
    private void Construct(LevelBuilder levelBuilder)
    {
        _atmosphere = levelBuilder.Atmosphere;
    }

    public void InitializeValues()
    {
        _image.fillAmount = _atmosphere.MinTemperature;
        _stepNumber = MaxImageValue / _atmosphere.MaxTemperature;
    }

    private void OnSetStep() => _stepNumber = MaxImageValue / _atmosphere.MaxTemperature;

    private void OnBeginChangeValue()
    {
        StopCoroutine();
        _valueChanger = StartCoroutine(ValueChanger());
    }

    private void OnInvokeReachedMaxValue()
    {
        StopCoroutine();
        _reachedMaxValue?.Invoke();
    }

    private void ShowPercent()
    {
        int value = (int)(_atmosphere.CurrentTemperature * _stepNumber * 100);
        _percent.text = value.ToString() + '%'; 
    }

    private void StopCoroutine()
    {
        if (_valueChanger != null)
            StopCoroutine(_valueChanger);
    }

    private IEnumerator ValueChanger()
    {
        float targetValue = _atmosphere.CurrentTemperature * _stepNumber;
        var waitTime = new WaitForEndOfFrame();

        while (_image.fillAmount != targetValue)
        {
            _image.fillAmount = Mathf.MoveTowards(_image.fillAmount, targetValue, Time.deltaTime);
            yield return waitTime;
        }

        if (_image.fillAmount == targetValue)
        {
            ShowPercent();
            yield break;
        }
    }
}
