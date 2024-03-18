using TMPro;
using UnityEngine;

public abstract class ObjectCountDisplayer : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textMeshPro;
    [SerializeField] private LevelObject _activeObject;

    private PlayerInstantiator _playerInstantiator;
    private GamePanel _gamePanel;

    protected int currentValue;

    protected LevelObject activeObject => _activeObject;

    private void Awake()
    {
        _gamePanel = GetComponentInParent<GamePanel>();
        _playerInstantiator = _gamePanel.PlayerInstantiator;
    }

    protected virtual void OnEnable()
    {
        _playerInstantiator.Created += OnSubscrubeOnPlayerCounter;

        if (_playerInstantiator.Player != null)
        {
            _playerInstantiator.Player.Counter.ValueChanged += UpdateValue;
        }

        SetDefaultValue();
    }

    protected virtual void OnDisable()
    {
        _playerInstantiator.Created -= OnUnsubscribeOnPlayerCounter;

        if (_playerInstantiator.Player != null)
            _playerInstantiator.Player.Counter.ValueChanged -= UpdateValue;
    }

    protected virtual void ShowValue()
    {
        textMeshPro.text = currentValue.ToString();
    }

    private void OnSubscrubeOnPlayerCounter(Player player)
    {
        player.Counter.ValueChanged += UpdateValue;
    }

    private void OnUnsubscribeOnPlayerCounter(Player player)
    {
        player.Counter.ValueChanged -= UpdateValue;
    }

    private void SetDefaultValue()
    {
        currentValue = 0;
        ShowValue();
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