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
        if (_isMoving == false)
            return;

        Vector3 targetPosition = _target.position + GetConvertedDistanceToTarget();
        Move(targetPosition, timeDeltaTime);
    }

    public void Move(Vector3 target, float timeDeltaTime)
    {
        Vector3 direction = target - _transform.position;
        float speed = Vector3.Distance(target, _transform.position) * _config.Speed;
        _transform.Translate(direction.normalized * speed * timeDeltaTime);
    }

    private Vector3 GetConvertedDistanceToTarget() => new Vector3(_config.DistanceToTarget, _config.DistanceToTarget, _config.DistanceToTarget);
}
