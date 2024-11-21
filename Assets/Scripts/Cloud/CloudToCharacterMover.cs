using UnityEngine;

public class CloudToCharacterMover : IMover
{
    private bool _isMoving;

    private Transform _transform;
    private Transform _target;

    private CloudUnderChatacterMoverConfig _config;

    public CloudToCharacterMover(Transform transform, Transform target, CloudUnderChatacterMoverConfig config)
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

        Move(timeDeltaTime);
    }

    public void Move(float timeDeltaTime) => _transform.position = Vector3.MoveTowards(_transform.position, _target.position, _config.Speed * timeDeltaTime);
}
