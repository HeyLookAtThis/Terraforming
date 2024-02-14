using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CloudState : State
{
    protected Vector3 positionIndent;
    protected Vector3 targetPosition;

    public float Speed => GetComponent<Cloud>().Player.Speed;

    public Transform Target => GetComponent<Cloud>().Player.transform;

    protected void Move(Vector3 direction)
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, Speed * Time.deltaTime);
    }
}
