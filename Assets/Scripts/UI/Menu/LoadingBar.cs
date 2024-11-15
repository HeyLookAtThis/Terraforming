using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    [SerializeField] private LoadingBarData _data;

    private Slider _slider;

    private Coroutine _filler;
    private float _filledTime;
    private float _minValue;

    private UnityAction _finished;
    private UnityAction _ranning;

    public event UnityAction Finished
    {
        add => _finished += value;
        remove => _finished -= value;
    }

    public event UnityAction Ran
    {
        add => _ranning += value;
        remove => _ranning -= value;
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();

        _minValue = 0;
        _filledTime = 3f;
        SetOnDefaultState();
    }

    private void OnEnable()
    {
        Run();
    }

    public void Run()
    {
        _data.SetRandomFact();
        _slider.value = _minValue;

        if (_filler != null)
            StopCoroutine(_filler);

        _filler = StartCoroutine(ValueAdder());
    }

    private void SetOnDefaultState()
    {
        _slider.value = _minValue;
        _slider.maxValue = _filledTime;
    }

    private IEnumerator ValueAdder()
    {
        var waitTime = new WaitForEndOfFrame();
        bool wasInvoked = false;
        float barScaleDiveder = 5f;

        while(_slider.value < _filledTime)
        {
            _slider.value += Time.deltaTime;

            if (_slider.value >= _filledTime - _filledTime / barScaleDiveder && !wasInvoked)
            {
                _ranning?.Invoke();
                wasInvoked = true;
            }

            yield return waitTime;
        }

        if(_slider.value == _filledTime)
        {
            _finished?.Invoke();
            yield break;
        }
    }
}
