using UnityEngine;

public class CameraDirectionIndicator : MonoBehaviour
{
    [SerializeField] private Transform _vartualCameraTransform;

    private float _currentYAxisAngle;
    private float _targetYAxisAngle;

    public Vector3 TargetDirection => new Vector3(0, _targetYAxisAngle, 0);

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        _currentYAxisAngle = transform.eulerAngles.y;
        _targetYAxisAngle = _vartualCameraTransform.eulerAngles.y;

        if (_targetYAxisAngle == _currentYAxisAngle)
            return;

        Quaternion targetRotation = Quaternion.Euler(TargetDirection);

        if (transform.rotation != targetRotation)
            transform.rotation = targetRotation;
    }
}
