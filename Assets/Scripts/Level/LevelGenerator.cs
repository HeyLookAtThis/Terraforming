using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(OldLevelCounter))]
public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private LoadingPanel _loading;

    private OldLevelCounter _counter;

    private UnityAction _launched;

    public event UnityAction Launched
    {
        add => _launched += value;
        remove => _launched -= value;
    }

    public uint CurrentLevel => _counter.CurrentLevel;

    private void Awake()
    {
        _counter = GetComponent<OldLevelCounter>();
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
