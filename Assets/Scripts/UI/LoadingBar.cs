using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    [SerializeField] private float _secondsToFill;
    [SerializeField] private int _triggerPercentValue;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _tmpro;

    private Coroutine _barFiller;
    private UnityAction _reachedTriggerValue;

    public event UnityAction ReachedTriggerValue
    {
        add => _reachedTriggerValue += value;
        remove => _reachedTriggerValue -= value;
    }

    private void OnEnable() => Run();

    private void Run()
    {
        _slider.value = _slider.minValue;

        if (_barFiller != null)
            StopCoroutine(_barFiller);

        _barFiller = StartCoroutine(BarFiller());
    }

    private IEnumerator BarFiller()
    {
        var waitTime = new WaitForEndOfFrame();
        float addedValue = _slider.maxValue / _secondsToFill;
        bool isReachedTriggerValue = false;

        while(_slider.value < _slider.maxValue)
        {
            _slider.value += addedValue * Time.deltaTime;

            if(_slider.value >= _triggerPercentValue && isReachedTriggerValue == false)
            {
                _reachedTriggerValue?.Invoke();
                isReachedTriggerValue = true;
            }

            _tmpro.text = $"{(int)_slider.value}%";
            yield return waitTime;
        }

        if (_slider.value >= _slider.maxValue)
            yield break;
    }
}
