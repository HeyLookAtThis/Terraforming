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

    private Coroutine _filler;

    public event UnityAction ReachedTriggerValue;
    public event UnityAction Filled;

    private void OnEnable() => Run();

    private void OnDisable() => ResetValue();

    private void Run()
    {
        if (_filler != null)
            StopCoroutine(_filler);

        _filler = StartCoroutine(BarFiller());
    }

    private IEnumerator BarFiller()
    {
        var waitTime = new WaitForEndOfFrame();
        float addedValue = _slider.maxValue / _secondsToFill;
        bool isReachedTriggerValue = false;

        while (_slider.value < _slider.maxValue)
        {
            _slider.value += addedValue * Time.deltaTime;

            if (_slider.value >= _triggerPercentValue && isReachedTriggerValue == false)
            {
                ReachedTriggerValue?.Invoke();
                isReachedTriggerValue = true;
            }

            _tmpro.text = $"{(int)_slider.value}%";
            yield return waitTime;
        }

        if (_slider.value >= _slider.maxValue)
        {
            Filled?.Invoke();
            yield break;
        }
    }

    private void ResetValue() => _slider.value = _slider.minValue;
}
