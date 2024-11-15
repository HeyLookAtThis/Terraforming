using UnityEngine;

[RequireComponent(typeof(Cloud))]
public class CloudBehaivorSwitcher : MonoBehaviour
{
    [SerializeField] private Transform _character;

    private Cloud _cloud;

    private void Awake()
    {
        _cloud = GetComponent<Cloud>();
        _cloud.SetMover(new EmptyCloudMover(transform, _character, _cloud.Config.EmptyCloudConfig));
    }
}
