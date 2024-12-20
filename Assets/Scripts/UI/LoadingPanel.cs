using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public class LoadingPanel : MonoBehaviour, IPanel
{
    [SerializeField] private float _secondsToFill;
    [SerializeField] private int _triggerPercentValue;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _tmpro;

    private IPanelSwitcher _switcher;
    private Bar _bar;

    public event UnityAction ReachedTriggerValue
    {
        add => _bar.ReachedTriggerValue += value;
        remove => _bar.ReachedTriggerValue -= value;
    }

    private void OnEnable()
    {
        _bar.Filled += OnSwitchToGamePanel;
        _bar.Run();
    }

    private void OnDisable() => _bar.Filled -= OnSwitchToGamePanel;

    [Inject]
    private void Construct(IPanelSwitcher switcher)
    {
        _switcher = switcher;
        _bar = new Bar(_secondsToFill, _triggerPercentValue, _slider, _tmpro, this);
    }

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    private void OnSwitchToGamePanel() => _switcher.SwitchPanel<GamePanel>();

    private class Bar
    {
        private float _secondsToFill;
        private int _triggerPercentValue;

        private Slider _slider;
        private TextMeshProUGUI _tmpro;

        private Coroutine _filler;
        private MonoBehaviour _monoBehaivor;

        public Bar(float secondsToFill, int triggerPercentValue, Slider slider, TextMeshProUGUI tmpro, MonoBehaviour monoBehaivor)
        {
            _secondsToFill = secondsToFill;
            _triggerPercentValue = triggerPercentValue;
            _slider = slider;
            _tmpro = tmpro;
            _monoBehaivor = monoBehaivor;
        }

        public event UnityAction ReachedTriggerValue;
        public event UnityAction Filled;

        public void Run()
        {
            _slider.value = _slider.minValue;

            if (_filler != null)
                _monoBehaivor.StopCoroutine(_filler);

            _filler = _monoBehaivor.StartCoroutine(BarFiller());
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
    }
}
