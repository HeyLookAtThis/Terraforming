using TMPro;
using UnityEngine;

public abstract class ObjectCountDisplayer : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textMeshPro;
    [SerializeField] private ActiveObject _activeObject;

    protected int currentValue;
    private GamePanel _gamePanel;

    protected ActiveObject activeObject => _activeObject;

    private void Awake()
    {
        _gamePanel = GetComponentInParent<GamePanel>();
    }

    private void OnEnable()
    {
        _gamePanel.Player.ObjectCountChanged += UpdateValue;
    }

    private void OnDisable()
    {
        _gamePanel.Player.ObjectCountChanged -= UpdateValue;
    }

    private void Start()
    {
        ShowValue();
    }

    protected virtual void ShowValue()
    {
        textMeshPro.text = currentValue.ToString();
    }

    private void UpdateValue(ActiveObject activeObject, int count)
    {
        if (this.activeObject.GetType() == activeObject.GetType())
        {
            currentValue = count;
            ShowValue();
        }
    }
}