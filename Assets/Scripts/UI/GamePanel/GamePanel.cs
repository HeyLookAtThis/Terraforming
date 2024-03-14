using UnityEngine;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private PlayerInstantiator _playerInstantiator;

    public PlayerInstantiator PlayerInstantiator => _playerInstantiator;
}
