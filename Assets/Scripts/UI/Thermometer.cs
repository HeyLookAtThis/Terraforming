using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Thermometer : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Coroutine _valueChanger;

    public void Initialize(Atmosphere atmosphere)
    {
        _slider.minValue = atmosphere.MinTemperature;
        _slider.maxValue = atmosphere.MaxTemperature;
        _slider.value = atmosphere.MinTemperature;
    }

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
            yield break;
    }
}
