using System;
using UnityEngine;

public class StateMachineData
{
    public Vector2 InputDirection;
    public float YVelocity;

    private float _speed;

    private float _currentTargetRotation;
    private float _timeToReachTargetRotation;
    private float _dampedTargetRotationCurrentVelocity;
    private float _dampedTargetRotationPassedTime;

    public float Speed
    {
        get => _speed;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _speed = value;
        }
    }

    public float CurrentTargetRotation
    {
        get => _currentTargetRotation;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _currentTargetRotation = value;
        }
    }

    public ref float DampedTargetRotationCurrentVelocity
    {
        get => ref _dampedTargetRotationCurrentVelocity;
    }

    public float DampedTargetRotationPassedTime
    {
        get => _dampedTargetRotationPassedTime;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _dampedTargetRotationPassedTime = value;
        }
    }

    public float TimeToReachTargetRotation
    {
        get => _timeToReachTargetRotation;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _timeToReachTargetRotation = value;
        }
    }
}
