using UnityEngine;

public class CloudInstantiator : MonoBehaviour
{
    [SerializeField] private Cloud _cloud;

    private PlayerInstantiator _playerInstantiator;
    private Cloud _createdCloud;

    private void Awake()
    {
        _playerInstantiator = GetComponent<PlayerInstantiator>();
    }

    private void OnEnable()
    {
        _playerInstantiator.Created += OnCreate;
    }

    private void OnDisable()
    {
        _playerInstantiator.Created -= OnCreate;
    }

    private void OnCreate(Player player)
    {
        if (_createdCloud != null)
            _createdCloud.Destroy();

        _createdCloud = Instantiate(_cloud, player.transform.position, Quaternion.identity);

        player.InitializeReservoir(_createdCloud.Reservoir);
        _createdCloud.Initialize(player);
    }
}