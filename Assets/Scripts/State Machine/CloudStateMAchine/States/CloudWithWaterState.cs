using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(OldCloud), typeof(CloudResizer))]
public class CloudWithWaterState : CloudState
{
    private const float _CloudSizeCoefficient = 0.7f;

    private CloudResizer _resizer;
    private bool _isInTargetPosition;

    private UnityAction _tookPosition;

    public event UnityAction TookPosition
    {
        add => _tookPosition += value;
        remove => _tookPosition -= value;
    }

    private void Awake()
    {
        _resizer = GetComponent<CloudResizer>();
    }

    private void OnEnable()
    {
        _resizer.ChangedValue += SetPositionIndent;
    }

    private void OnDisable()
    {
        _resizer.ChangedValue -= SetPositionIndent;
    }

    private void Update()
    {
        targetPosition = Target.position + positionIndent;

        Move(targetPosition, TargetSpeed * SpeedBoost);

        transform.forward = Target.forward;
        ConfigureIsInTargetPlace();

        if (_isInTargetPosition)
        {
            transform.position = targetPosition;
            _tookPosition?.Invoke();
        }
    }

    private void ConfigureIsInTargetPlace()
    {
        float allowedDistance = 0.35f;

        if (Vector3.Distance(targetPosition, transform.position) < allowedDistance)
            _isInTargetPosition = true;
        else
            _isInTargetPosition = false;
    }

    private void SetPositionIndent()
    {
        positionIndent.y = _CloudSizeCoefficient - _resizer.CurrentValue;
    }
}