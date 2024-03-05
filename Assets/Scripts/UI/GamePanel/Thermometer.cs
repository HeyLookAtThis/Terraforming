using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Thermometer : MonoBehaviour
{    
    [SerializeField] private Ground _ground;

    private Coroutine _valueChanger;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _ground.TemperatureSet += Initialize;
        _ground.TemperatureChanged += BeginChangeValue;
    }

    private void OnDisable()
    {
        _ground.TemperatureSet -= Initialize;
        _ground.TemperatureChanged -= BeginChangeValue;
    }

    public void Initialize()
    {
        _slider.minValue = _ground.StartingTemperature;
        _slider.maxValue = _ground.EndingTemperature;
        _slider.value = _ground.StartingTemperature;
    }

    public void BeginChangeValue()
    {
        if (_valueChanger != null)
            StopCoroutine(_valueChanger);

        _valueChanger = StartCoroutine(ValueChanger());
    }

    private IEnumerator ValueChanger()
    {
        float seconds = 0.02f;        
        var waitTime = new WaitForSeconds(seconds);

        float fillingSpeed = 0.5f;

        while (_slider.value != _ground.CurrentTemperature)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _ground.CurrentTemperature, fillingSpeed);
            yield return waitTime;
        }

        if (_slider.value == _ground.CurrentTemperature)
            yield break;
    }
}