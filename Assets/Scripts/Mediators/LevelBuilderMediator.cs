using UnityEngine;

public class LevelBuilderMediator : MonoBehaviour
{
    [SerializeField] private LoadingPanel _loadingPanel;
    [SerializeField] private LevelBuilder _levelBuilder;

    private void OnEnable() => _loadingPanel.ReachedTriggerValue += _levelBuilder.OnStartLevel;

    private void OnDisable() => _loadingPanel.ReachedTriggerValue -= _levelBuilder.OnStartLevel;
}
