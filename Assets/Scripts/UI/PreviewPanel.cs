using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class PreviewPanel : MonoBehaviour, IPanel, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI _tMPro;

    private FlashingText _flashingText;
    private IPanelSwitcher _panelSwitcher;

    private void OnEnable() => _flashingText.Run();

    public void OnPointerClick(PointerEventData eventData)
    {
        _flashingText.WasClicked = true;
        _panelSwitcher.SwitchPanel<LoadingPanel>();
    }

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    [Inject]
    private void Construct(IPanelSwitcher panelSwitcher)
    {
        _flashingText = new FlashingText(_tMPro, _tMPro.color, this);
        _panelSwitcher = panelSwitcher;
    }

    private class FlashingText
    {
        public bool WasClicked;

        private TextMeshProUGUI _tMPro;

        private Color _transparentColor;
        private Color _defaultColor;

        private Coroutine _textFlasher;
        private MonoBehaviour _monoBehaivor;

        public FlashingText(TextMeshProUGUI tMPro, Color defaultColor, MonoBehaviour monoBegaivor)
        {
            _tMPro = tMPro;
            _defaultColor = defaultColor;

            _transparentColor = _defaultColor;
            _transparentColor.a = 0;
            _monoBehaivor = monoBegaivor;
        }

        public void Run()
        {
            WasClicked = false;

            if (_textFlasher != null)
                _monoBehaivor.StopCoroutine(_textFlasher);

            _textFlasher = _monoBehaivor.StartCoroutine(TextFlasher());
        }

        private IEnumerator TextFlasher()
        {
            var waitTime = new WaitForEndOfFrame();
            float flashSpeed = 20f;

            bool isGainingColor = false;

            while (WasClicked == false)
            {
                if (isGainingColor == false)
                    _tMPro.DOColor(_transparentColor, Time.deltaTime * flashSpeed);
                else
                    _tMPro.DOColor(_defaultColor, Time.deltaTime * flashSpeed);

                if (_tMPro.color == _transparentColor)
                    isGainingColor = true;
                else if (_tMPro.color == _defaultColor)
                    isGainingColor = false;

                yield return waitTime;
            }

            if (WasClicked)
                yield break;
        }
    }
}