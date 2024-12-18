using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Preview : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI _tMPro;

    private Coroutine _textFlasher;
    private bool _wasClicked;

    private Color _transparentColor;
    private Color _defaultColor;

    private UnityAction _clicked;

    public event UnityAction Clicked
    {
        add => _clicked += value;
        remove => _clicked -= value;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _wasClicked = true;
        _clicked?.Invoke();
    }

    private void OnEnable()
    {
        InitializeColors();
        Run();
    }

    private void Run()
    {
        if (_textFlasher != null)
            StopCoroutine(_textFlasher);

        _textFlasher = StartCoroutine(TextFlasher());
    }

    private void InitializeColors()
    {
        _transparentColor = Color.white;
        _transparentColor.a = 0;

        _defaultColor = Color.white;
    }

    private IEnumerator TextFlasher()
    {
        var waitTime = new WaitForEndOfFrame();
        float flashSpeed = 20f;

        bool isGainingColor = false;

        while (_wasClicked == false)
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

        if (_wasClicked)
            yield break;
    }
}
