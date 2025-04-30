using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GamePanel _gamePanel;

    private void Awake()
    {
        _ = new ObjectSounder(_audioSource, _gamePanel);
    }
}
