using UnityEngine;
using UnityEngine.Events;

public class GameplayChecker : MonoBehaviour
{
    [SerializeField] private GamePanel _gamePanel;

    private UnityAction<bool> _update;

    public event UnityAction<bool> Update
    {
        add => _update += value;
        remove => _update -= value;
    }

    private void OnEnable()
    {
        _gamePanel.GameplayChanged += SetIsPlaying;
    }

    private void OnDisable()
    {
        _gamePanel.GameplayChanged -= SetIsPlaying;
    }

    private void SetIsPlaying(bool isGamePlaying)
    {
        _update?.Invoke(isGamePlaying);
    }
}
