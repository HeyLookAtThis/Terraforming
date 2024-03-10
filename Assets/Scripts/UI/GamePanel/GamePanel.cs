using UnityEngine;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private PlayerInstantiator _playerInstantiator;

    private PlayerObjectsCounter _playerObjectsCounter;

    public PlayerObjectsCounter Player => _playerObjectsCounter;

    public PlayerInstantiator PlayerInstantiator => _playerInstantiator;

    private void OnEnable()
    {
        _playerInstantiator.Created += OnInitialize;
    }

    private void OnDisable()
    {
        _playerInstantiator.Created -= OnInitialize;
    }

    private void OnInitialize(Player player)
    {
        _playerObjectsCounter = player.Counter;
        player.InitializeJoystic(GetComponentInChildren<FixedJoystick>());
    }
}
