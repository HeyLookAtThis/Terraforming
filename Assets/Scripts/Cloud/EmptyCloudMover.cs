using UnityEngine;

public class EmptyCloudMover : IMover
{
    private bool _isMoving;

    private Transform _transform;
    private Transform _target;

    private EmptyCloudConfig _config;

    public EmptyCloudMover(Transform transform, Transform target, EmptyCloudConfig config)
    {
        _transform = transform;
        _target = target;
        _config = config;
    }

    public Transform Transform => _transform;
    public Transform Target => _target;

    public void StartMove() => _isMoving = true;
    public void StopMove() => _isMoving = false;

    public void Update(float timeDeltaTime)
    {
        CheckRelocetionNeeds();

        if (_isMoving == false)
            return;

        Move(timeDeltaTime);
    }

    public void Move(float timeDeltaTime) => _transform.position = Vector3.MoveTowards(_transform.position, _target.position, GetCurrentSpeed(timeDeltaTime));

    private void CheckRelocetionNeeds()
    {
        if(GetDistanceToTarget() >= _config.MinDistanceToTarget && GetDistanceToTarget() <= _config.MaxDistanceToTarget)
            StopMove();
        else
            StartMove();
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = GetToTargetDirection();

        //if (GetDistanceToTarget() > _config.MinDistanceToTarget)
        //    direction = GetToTargetDirection();
        //else
        //    direction = GetFromTargetDirection();

        return direction.normalized;
    }

    private float GetDistanceToTarget() => Vector3.Distance(_target.transform.position, _transform.position);
    private Vector3 GetToTargetDirection() => _target.position/* - _transform.position*/;
    private Vector3 GetFromTargetDirection() => _transform.position - _target.position;
    private float GetCurrentSpeed(float timeDeltatime) => GetDistanceToTarget() * _config.MovementSpeedMultiplier * timeDeltatime;
}
