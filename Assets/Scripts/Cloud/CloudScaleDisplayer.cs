using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CloudScaleDisplayer : MonoBehaviour
{
    [SerializeField] private Transform _cloud;
    [SerializeField] private Image _image;

    private CameraDirectionIndicator _cameraDirectionIndicator;
    private Resizer _resizer;

    private float YPosition => 1.1f;

    private void Update()
    {
        transform.SetPositionAndRotation(new Vector3(_cloud.position.x, YPosition, _cloud.position.z), Quaternion.Euler(_cameraDirectionIndicator.TargetDirection));

        if (_image.fillAmount != _resizer.CurrentScale)
            _image.fillAmount = _resizer.CurrentScale;
    }

    public void Initialize(Resizer resizer)
    {
        _resizer = resizer;
    }

    [Inject]
    private void Construct(CameraDirectionIndicator cameraDirectionIndicator) => _cameraDirectionIndicator = cameraDirectionIndicator;
}