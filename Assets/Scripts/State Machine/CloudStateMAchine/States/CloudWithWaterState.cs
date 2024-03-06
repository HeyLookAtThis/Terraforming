using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Cloud), typeof(CloudResizer))]
public class CloudWithWaterState : CloudState
{
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

        Move(targetPosition);

        parentTransform.forward = Target.forward;
        ConfigureIsInTargetPlace();

        if (_isInTargetPosition)
            _tookPosition?.Invoke();
    }

    private void ConfigureIsInTargetPlace()
    {
        if(parentTransform.position.x == Target.position.x && parentTransform.position.z == Target.position.z)
            _isInTargetPosition = true;
        else
            _isInTargetPosition = false;
    }

    private void SetPositionIndent(float difference)
    {
        positionIndent.y = 0.7f - difference;
    }
}