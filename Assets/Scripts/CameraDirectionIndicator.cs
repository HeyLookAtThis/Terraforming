using UnityEngine;

public class CameraDirectionIndicator : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;

    private float _currentYAxisAngle;
    private float _targetYAxisAngle;

    public Vector3 TargetDirection => new Vector3(0, _targetYAxisAngle, 0);

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        if(transform.position == _targetTransform.position)
            return;

        transform.position = _targetTransform.position;
    }

    private void Rotate()
    {
        _currentYAxisAngle = transform.eulerAngles.y;
        _targetYAxisAngle = _targetTransform.eulerAngles.y;

        if (_targetYAxisAngle == _currentYAxisAngle)
            return;

        Quaternion targetRotation = Quaternion.Euler(TargetDirection);

        if (transform.rotation != targetRotation)
            transform.rotation = targetRotation;
    }
}
