using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TitlePanel : Panel, IPointerClickHandler
{
    [SerializeField] private AudioClip _sound;

    private TextMeshProUGUI _textMeshPro;
    private AudioSource _audioSource;
    private bool _isClicked;

    private UnityAction _clicked;

    public event UnityAction Clicked
    {
        add => _clicked += value;
        remove => _clicked -= value;
    }

    private void Awake()
    {
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        _audioSource = GetComponentInChildren<AudioSource>();

        _audioSource.clip = _sound;
    }

    private void OnEnable()
    {
        _audioSource?.Play();
        StartCoroutine(TextBlinker());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       _isClicked = true;
        _clicked?.Invoke();
    }

    private IEnumerator TextBlinker()
    {
        float seconds = 0.5f;
        var waitTime = new WaitForSeconds(seconds);

        var defaultColor = _textMeshPro.color;
        var transparentColor = new Color(255, 255, 255, 0);

        bool isGainingColor = false;

        while (!_isClicked)
        {
            if (!isGainingColor)
                _textMeshPro.DOColor(transparentColor, seconds);
            else
                _textMeshPro.DOColor(defaultColor, seconds);

            if(_textMeshPro.color == transparentColor)
                isGainingColor = true;
            else if(_textMeshPro.color == defaultColor)
                isGainingColor = false;

            yield return waitTime;
        }

        if(_isClicked)
        {
            yield break;
        }
    }
}
