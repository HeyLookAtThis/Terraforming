using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EndGamePanel : MonoBehaviour
{
    private UnityAction _restartAction;

    public event UnityAction RestartAction
    {
        add => _restartAction += value;
        remove => _restartAction -= value;
    }

    public void OnRestartLevel()
    {
        _restartAction?.Invoke();
    }
}
