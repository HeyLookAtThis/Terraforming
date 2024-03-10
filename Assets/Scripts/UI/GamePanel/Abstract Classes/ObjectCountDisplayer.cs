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
        _gamePanel.PlayerInstantiator.Created += Subscribe;
    }

    private void OnDisable()
    {
        _gamePanel.PlayerInstantiator.Created += Unsubscribe;
    }

    private void Start()
    {
        ShowValue();
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

    private void Subscribe(Player player)
    {
        player.Counter.ValueChanged += UpdateValue;
    }

    private void Unsubscribe(Player player)
    {
        player.Counter.ValueChanged -= UpdateValue;
    }
}