using UnityEngine;
using UnityEngine.Events;

public class PlayerInstantiator : MonoBehaviour
{
    [SerializeField] private Player _player;

    private LevelGenerator _levelGenerator;
    private Player _createdPlayer;
    private float _jumpHeight;
    private Water _water;

    private UnityAction<Player> _created;

    public event UnityAction<Player> Created
    {
        add => _created += value;
        remove => _created -= value;
    }

    private void Awake()
    {
        _levelGenerator = GetComponent<LevelGenerator>();
        _water = GetComponentInChildren<Water>();
        _jumpHeight = 4f;
    }

    private void OnEnable()
    {
        _levelGenerator.Launched += OnCreate;
    }

    private void OnDisable()
    {
        _levelGenerator.Launched -= OnCreate;
    }

    private void OnCreate(uint currentLevel)
    {
        if (_createdPlayer != null)
            _createdPlayer.Destroy();

        _createdPlayer = Instantiate(_player, new Vector3(_water.transform.position.x, _jumpHeight, _water.transform.position.z), Quaternion.identity);
        _created?.Invoke(_createdPlayer);
    }
}