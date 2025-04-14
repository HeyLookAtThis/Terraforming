using UnityEngine;
using UnityEngine.UI;

public class CloudScaleDisplayer : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private RectTransform _rectTransform;

    private Resizer _resizer;

    private Quaternion _rotation => new Quaternion(0, 90, 90, 1);

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (_rectTransform.rotation != _rotation)
            _rectTransform.rotation = _rotation;

        if (_image.fillAmount != _resizer.CurrentPercent)
            _image.fillAmount = _resizer.CurrentPercent;
    }

    public void InitializeResizer(Resizer resizer) => _resizer = resizer;
}