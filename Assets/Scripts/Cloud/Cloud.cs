using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;

    public PlayerMovement Player => _player;
}
