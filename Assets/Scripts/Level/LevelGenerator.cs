using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LevelCounter))]
public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private LoadingPanel _loading;

    private LevelCounter _counter;

    private UnityAction _launched;

    public event UnityAction Launched
    {
        add => _launched += value;
        remove => _launched -= value;
    }

    public uint CurrentLevel => _counter.CurrentLevel;

    private void Awake()
    {
        _counter = GetComponent<LevelCounter>();
    }

    private void OnEnable()
    {
        _loading.Bar.Ran += OnLaunch;
    }

    private void OnDisable()
    {
        _loading.Bar.Ran -= OnLaunch;
    }

    private void OnLaunch()
    {
        _launched?.Invoke();
    }
}
