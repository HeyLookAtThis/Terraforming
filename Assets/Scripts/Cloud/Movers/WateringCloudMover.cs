using UnityEngine;
using UnityEngine.Events;

public class WateringCloudMover : IMover
{
    private bool _isMoving;

    private Transform _transform;
    private Transform _target;
    private UnityAction<bool> _changedState;
    private UnityAction _updated;

    public WateringCloudMover(Transform transform, Transform target)
    {
        _transform = transform;
        _target = target;
    }

    public event UnityAction<bool> ChangedActivity
    {
        add => _changedState += value;
        remove => _changedState -= value;
    }

    public event UnityAction Updated
    {
        add => _updated += value;
        remove => _updated -= value;
    }

    public Transform Transform => _transform;
    public Transform Target => _target;

    public void StartMove()
    {
        _isMoving = true;
        _changedState?.Invoke(_isMoving);
    }
    public void StopMove()
    {
        _isMoving = false;
        _changedState?.Invoke(_isMoving);
    }

    public void Update(float timeDeltaTime)
    {
        if (_isMoving == false)
            return;

        Move(timeDeltaTime);
        Rotate();
        _updated?.Invoke();
    }

    public void Move(float timeDeltaTime) => _transform.position = _target.transform.position;
    private void Rotate() => _transform.forward = _target.transform.forward;
}
