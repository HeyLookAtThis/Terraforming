using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    private UnityAction _restartAction;

    public event UnityAction RestartAction
    {
        add => _restartAction += value;
        remove => _restartAction -= value;
    }

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartLevel);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartLevel);
    }

    private void OnRestartLevel()
    {
        _restartAction?.Invoke();
    }
}
