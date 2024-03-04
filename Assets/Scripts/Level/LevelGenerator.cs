using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LevelCounter))]
public class LevelGenerator : MonoBehaviour
{
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
    }

    private void Start()
    {
        _launched?.Invoke(_levelCounter.CurrentLevel);
    }
}
