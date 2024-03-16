using TMPro;
using UnityEngine;

public abstract class ObjectCountDisplayer : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textMeshPro;
    [SerializeField] private LevelObject _activeObject;

    private PlayerObjectsCounter _playerObjectsCounter;
    private PlayerInstantiator _playerInstantiator;
    private GamePanel _gamePanel;

    protected int currentValue;

    protected LevelObject activeObject => _activeObject;

    private void Awake()
    {
        _gamePanel = GetComponentInParent<GamePanel>();
        _playerInstantiator = _gamePanel.PlayerInstantiator;
    }

    private void OnEnable()
    {
        _playerInstantiator.Created += OnInitializePlayer;
        _gamePanel.LevelGenerator.Launched += SetDefaultValue;
    }

    private void OnDisable()
    {
        _playerInstantiator.Created -= OnInitializePlayer;
        _gamePanel.LevelGenerator.Launched -= SetDefaultValue;

        if (_playerObjectsCounter != null)
            _playerObjectsCounter.ValueChanged -= UpdateValue;
    }

    protected virtual void ShowValue()
    {
        textMeshPro.text = currentValue.ToString();
    }

    private void SetDefaultValue()
    {
        currentValue = 0;
        ShowValue();
    }

    private void OnInitializePlayer(Player player)
    {
        _playerObjectsCounter = player.Counter;
        _playerObjectsCounter.ValueChanged += UpdateValue;
    }

    private void UpdateValue(LevelObject activeObject, int count)
    {
        if (this.activeObject.GetType() == activeObject.GetType())
        {
            currentValue = count;
            ShowValue();
        }
    }
}