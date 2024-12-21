using UnityEngine;

public class LevelBuilderMediator : MonoBehaviour
{
    [SerializeField] private LoadingBar _loadingBar;
    [SerializeField] private LevelBuilder _levelBuilder;

    private void OnEnable() => _loadingBar.ReachedTriggerValue += _levelBuilder.OnStartLevel;

    private void OnDisable() => _loadingBar.ReachedTriggerValue -= _levelBuilder.OnStartLevel;
}
