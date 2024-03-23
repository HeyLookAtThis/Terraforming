using UnityEngine;

public class Cloud : MonoBehaviour
{
    private PlayerColliderChecker _playerColliderChecker;
    private PlayerObjectsCounter _playerObjectCounter;
    private PlayerMovement _playerMovement;

    private GameplayChecker _gameplayChecker;

    public PlayerObjectsCounter Player => _playerObjectCounter;

    public PlayerMovement PlayerMovement => _playerMovement;

    public PlayerColliderChecker PlayerColliderChecker => _playerColliderChecker;

    public CloudReservoir Reservoir => GetComponent<CloudReservoir>();

    public GameplayChecker GameplayChecker => _gameplayChecker;

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void Initialize(Player player, GameplayChecker gameplayChecker)
    {
        _playerColliderChecker = player.ColliderChecker;
        _playerObjectCounter = player.Counter;
        _playerMovement = player.Movement;

        _gameplayChecker = gameplayChecker;
    }
}
