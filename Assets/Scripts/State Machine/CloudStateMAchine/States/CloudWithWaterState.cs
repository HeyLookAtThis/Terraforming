using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Cloud), typeof(CloudResizer))]
public class CloudWithWaterState : CloudState
{
    private float _lowYPositionIndent;
    private float _highYPositionIndent;

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

        _lowYPositionIndent = 0.3f;
        _highYPositionIndent = -0.3f;

        targetPosition = Target.position - positionIndent;
    }

    //private void OnEnable()
    //{
    //    positionIndent.y = _lowYPositionIndent;
    //    _resizer.ChangedValue += SetPositionIndent;   
    //}

    //private void OnDisable()
    //{
    //    _resizer.ChangedValue -= SetPositionIndent;
    //}

    private void Update()
    {
        targetPosition = Target.position - positionIndent;

        Debug.Log(positionIndent.y);

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

    //private void SetPositionIndent()
    //{
    //    if (positionIndent.y >= _highYPositionIndent && positionIndent.y <= _lowYPositionIndent)
    //        positionIndent.y -= (_lowYPositionIndent - _highYPositionIndent) / _resizer.DivisionsNumber;
    //}
}