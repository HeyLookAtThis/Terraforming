using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EndGamePanel : MonoBehaviour
{
    //[SerializeField] private Button _restartButton;

    private UnityAction _restartAction;

    public event UnityAction RestartAction
    {
        add => _restartAction += value;
        remove => _restartAction -= value;
    }

    //private void Awake()
    //{
    //    _restartButton = GetComponentInChildren<Button>();
    //}

    //private void OnEnable()
    //{
    //    _restartButton.clicked += OnRestartLevel;
    //}

    //private void OnDisable()
    //{
    //    _restartButton.clicked -= OnRestartLevel;
    //}

    public void OnRestartLevel()
    {
        _restartAction?.Invoke();
    }
}
