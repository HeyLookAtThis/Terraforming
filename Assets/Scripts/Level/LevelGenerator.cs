using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LevelCounter))]
public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private EndGamePanel _endGamePanel;

    private LevelCounter _levelCounter;

    private UnityAction<uint> _launched;


    public event UnityAction<uint> Launched
    {
        add => _launched += value;
        remove => _launched -= value;
    }

    private void Awake()
    {
        _levelCounter = GetComponent<LevelCounter>();
        OnLaunch();
    }

    private void OnEnable()
    {
        _endGamePanel.RestartAction += OnLaunch;
    }

    private void OnDisable()
    {
        _endGamePanel.RestartAction -= OnLaunch;
    }

    private void OnLaunch()
    {
        _launched?.Invoke(_levelCounter.CurrentLevel);
    }
}
