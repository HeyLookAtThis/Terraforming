using UnityEngine;
using UnityEngine.UI;

public class CloudReservoirScaleDisplayer : MonoBehaviour
{
    [SerializeField] private CloudReservoir _reservoir;
    [SerializeField] private Sprite _picture;

    private RectTransform _rectTransform;

    private Quaternion _rotation;
    private Image _image;
    private float _totalValue;
    private float _previousValue;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
        _image.sprite = _picture;
    }

    private void OnEnable()
    {
        _reservoir.ChangedValue += OnChangeValue;
    }

    private void OnDisable()
    {
        _reservoir.ChangedValue -= OnChangeValue;
    }

    private void Start()
    {
        _rotation = new Quaternion(0, 90, 90, 1);
        _totalValue = 1;
        _image.fillAmount = _totalValue;
    }

    private void Update()
    {
        _rectTransform.rotation = _rotation;
    }

    private void OnChangeValue()
    {
        if (_reservoir.CurrentValue > _previousValue)
        {
            _image.fillAmount += _totalValue / _reservoir.DivisionsNumber;
            _previousValue = _reservoir.CurrentValue;
        }
        else
        {
            _image.fillAmount -= _totalValue / _reservoir.DivisionsNumber;
            _previousValue = _reservoir.CurrentValue;
        }
    }
}