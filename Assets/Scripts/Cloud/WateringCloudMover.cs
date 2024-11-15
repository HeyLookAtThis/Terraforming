using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCloudMover : IMover
{
    private Transform _transform;
    private Transform _target;

    public Transform Transform => throw new System.NotImplementedException();

    public Transform Target => throw new System.NotImplementedException();

    public void Move(Vector3 translation, float timeDeltaTime)
    {
        _transform.position = _target.position;
    }

    public void StartMove()
    {
        throw new System.NotImplementedException();
    }

    public void StopMove()
    {
        throw new System.NotImplementedException();
    }

    public void Update(float timeDeltaTime)
    {
        throw new System.NotImplementedException();
    }
}
