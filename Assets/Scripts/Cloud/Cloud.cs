using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerColliderChecker _playerColliderChecker;
    [SerializeField] private Ground _ground;

    public Player Player => _player;

    public PlayerMovement PlayerMovement => _playerMovement;

    public PlayerColliderChecker PlayerColliderChecker => _playerColliderChecker;

    public Ground Ground => _ground;
}
