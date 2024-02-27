using UnityEngine;
using UnityEngine.Events;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private LevelGrid _grid;
    [SerializeField] private Water _water;
    [SerializeField] private LevelCounter _levelCounter;

    private UnityAction<uint> _launched;

    public event UnityAction<uint> Launched
    {
        add => _launched += value;
        remove => _launched -= value;
    }

    private void Start()
    {
        _launched?.Invoke(_levelCounter.CurrentLevel);
    }
}
