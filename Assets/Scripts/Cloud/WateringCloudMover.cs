using UnityEngine;

public class WateringCloudMover : IMover
{
    private bool _isMoving;

    private Transform _transform;
    private Transform _target;

    public WateringCloudMover(Transform transform, Transform target)
    {
        _transform = transform;
        _target = target;
    }

    public Transform Transform => _transform;

    public Transform Target => _target;

    public void StartMove() => _isMoving = true;

    public void StopMove() => _isMoving = false;

    public void Update(float timeDeltaTime)
    {
        if (_isMoving == false)
            return;

        Move(timeDeltaTime);
        Rotate();
    }

    public void Move(float timeDeltaTime) => _transform.position = _target.transform.position;

    private void Rotate() => _transform.forward = _target.transform.forward;
}
