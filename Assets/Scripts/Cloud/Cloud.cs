using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private PlayerColliderChecker _playerColliderChecker;

    public PlayerMovement PlayerMovement => _player;

    public PlayerColliderChecker PlayerColliderChecker => _playerColliderChecker;
}
