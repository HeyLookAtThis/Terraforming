using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuPanel : Panel
{
    [SerializeField] private AudioClip _sound;
    [SerializeField] private TitlePanel _title;

    private AudioSource _audioSource;

    private StartButton _start;
    private RatingButton _rating;
    private SettingButton _setting;

    private GameButton[] _buttons;

    private LoadingBar _loadingBar;

    public LoadingBar LoadingBar => _loadingBar;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _sound;

        _start = GetComponentInChildren<StartButton>();
        _rating = GetComponentInChildren<RatingButton>();
        _setting = GetComponentInChildren<SettingButton>();
        _loadingBar = GetComponentInChildren<LoadingBar>();

        _buttons = new GameButton[] { _start, _rating, _setting };
    }

    private void OnEnable()
    {
        _audioSource.Play();
        _loadingBar.gameObject.SetActive(false);
        SetButtonsVisible();

        _start.AddListener(_loadingBar.Run);
        _start.AddListener(SetButtonsVisible);
    }

    private void OnDisable()
    {
        _audioSource.Stop();

        _start.RemoveListener(_loadingBar.Run);
        _start.RemoveListener(SetButtonsVisible);
    }

    private void SetButtonsVisible()
    {
        foreach (var button in _buttons)
        {
            if (button.gameObject.activeSelf)
                button.gameObject.SetActive(false);
            else
                button.gameObject.SetActive(true);
        }
    }
}
