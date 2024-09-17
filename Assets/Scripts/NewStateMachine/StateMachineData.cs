using System;
using UnityEngine;

public class StateMachineData
{
    public Vector2 InpudDirection;

    private float _speed;
    private float _currentTargetRotation;

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
}
