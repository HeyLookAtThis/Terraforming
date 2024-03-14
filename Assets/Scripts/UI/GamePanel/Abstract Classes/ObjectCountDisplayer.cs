using TMPro;
using UnityEngine;

public abstract class ObjectCountDisplayer : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textMeshPro;
    [SerializeField] private LevelObject _activeObject;

    protected int currentValue;
    private GamePanel _gamePanel;

    protected LevelObject activeObject => _activeObject;

    private void Awake()
    {
        _gamePanel = GetComponentInParent<GamePanel>();
    }

    private void OnEnable()
    {
        currentValue = 0;
        ShowValue();

        if (_gamePanel.PlayerInstantiator.Player != null)
            _gamePanel.PlayerInstantiator.Player.Counter.ValueChanged += UpdateValue;
    }

    private void OnDisable()
    {
        if (_gamePanel.PlayerInstantiator.Player != null)
            _gamePanel.PlayerInstantiator.Player.Counter.ValueChanged -= UpdateValue;
    }

    protected virtual void ShowValue()
    {
        textMeshPro.text = currentValue.ToString();
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