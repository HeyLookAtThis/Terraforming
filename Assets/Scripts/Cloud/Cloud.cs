using UnityEngine;

public class Cloud : MonoBehaviour
{
    private PlayerColliderChecker _playerColliderChecker;
    private PlayerObjectsCounter _playerObjectCounter;
    private PlayerMovement _playerMovement;

    public PlayerObjectsCounter Player => _playerObjectCounter;

    public PlayerMovement PlayerMovement => _playerMovement;

    public PlayerColliderChecker PlayerColliderChecker => _playerColliderChecker;

    public CloudReservoir Reservoir => GetComponent<CloudReservoir>();

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void Initialize(Player player)
    {
        _playerColliderChecker = player.ColliderChecker;
        _playerObjectCounter = player.Counter;
        _playerMovement = player.Movement;
    }
}
