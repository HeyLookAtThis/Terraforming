using UnityEngine;
using UnityEngine.Events;

public class WateringCloudMover : IMover
{
    private bool _isMoving;
    private float _wateringTime;

    private Transform _transform;
    private Transform _target;

    private UnityAction _waterIsOver;

    public WateringCloudMover(Transform transform, Transform target)
    {
        _transform = transform;
        _target = target;
        _wateringTime = 3f;
    }

    public event UnityAction WaterIsOver
    {
        add => _waterIsOver += value;
        remove => _waterIsOver -= value;
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

        _wateringTime -= Time.deltaTime;

        if(_wateringTime <=0)
            _waterIsOver?.Invoke();
    }

    public void Move(float timeDeltaTime)
    {
        _transform.position = _target.transform.position;
    }

    private void Rotate() => _transform.forward = _target.transform.forward;
}
