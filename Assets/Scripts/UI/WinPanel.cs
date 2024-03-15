using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _continueButton;

    private UnityAction _restartButtonClicked;
    private UnityAction _continueButtonClicked;

    public event UnityAction RestartButtonClicked
    {
        add => _restartButtonClicked += value;
        remove => _restartButtonClicked -= value;
    }

    public event UnityAction ContinueButtonClicked
    {
        add => _continueButtonClicked += value;
        remove => _continueButtonClicked -= value;
    }

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _continueButton.onClick.AddListener(OnContinueButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
    }

    private void OnRestartButtonClick()
    {
        _restartButtonClicked?.Invoke();
    }

    private void OnContinueButtonClick()
    {
        _continueButtonClicked?.Invoke();
    }
}
