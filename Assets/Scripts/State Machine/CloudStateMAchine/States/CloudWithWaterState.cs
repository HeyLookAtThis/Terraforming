using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Cloud), typeof(CloudResizer))]
public class CloudWithWaterState : CloudState
{
    private CloudResizer _resizer;

    private float _cloudSizeCoefficient;

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
        _cloudSizeCoefficient = 4f;
        targetPosition = Target.position - positionIndent;
    }

    private void Update()
    {
        positionIndent.y = _resizer.CurrentValue / _cloudSizeCoefficient;
        targetPosition = Target.position - positionIndent;

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
}