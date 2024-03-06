using UnityEngine;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private Player _player;

    public Player Player => _player;
}
