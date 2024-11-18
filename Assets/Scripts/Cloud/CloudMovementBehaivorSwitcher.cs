using UnityEngine;

[RequireComponent(typeof(Cloud))]
public class CloudMovementBehaivorSwitcher : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Cloud _cloud;

    private void Awake()
    {
        _cloud = GetComponent<Cloud>();
        _cloud.SetMover(new EmptyCloudMover(_cloud.transform, _target, _cloud.Config.EmptyCloudConfig));
    }
}
