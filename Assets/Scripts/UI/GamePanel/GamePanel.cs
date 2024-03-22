using UnityEngine;
using UnityEngine.Events;

public class GamePanel : Panel
{
    [SerializeField] private PlayerInstantiator _playerInstantiator;
    [SerializeField] private LevelGenerator _levelGenerator;

    private bool _isPlaying;

    private UnityAction<bool> _gameplayChanged;

    public event UnityAction<bool> GameplayChanged
    {
        add => _gameplayChanged += value;
        remove => _gameplayChanged -= value;
    }

    public PlayerInstantiator PlayerInstantiator => _playerInstantiator;

    private void OnEnable()
    {
        _isPlaying = true;
        _gameplayChanged?.Invoke(_isPlaying);
    }

    private void OnDisable()
    {
        _isPlaying = false;
        _gameplayChanged?.Invoke(_isPlaying);
    }
}
