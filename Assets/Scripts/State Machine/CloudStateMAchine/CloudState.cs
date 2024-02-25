using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CloudState : State
{
    [SerializeField] private float _speedBoost;
    [SerializeField] protected Transform parentTransform;

    protected Vector3 positionIndent;
    protected Vector3 targetPosition;

    protected float speed;

    private Coroutine _positionChanger;

    public float TargetSpeed => GetComponent<Cloud>().PlayerMovement.Speed;

    public Transform Target => GetComponent<Cloud>().PlayerMovement.transform;

    public override void Enter()
    {
        base.Enter();
        speed = TargetSpeed * _speedBoost;
        //BeginChangePosition();
    }

    protected void Move(Vector3 direction)
    {
        parentTransform.position = Vector3.MoveTowards(parentTransform.position, direction, speed * Time.deltaTime);
    }

    //private void BeginChangePosition()
    //{
    //    if (_positionChanger != null)
    //        StopCoroutine(_positionChanger);

    //    _positionChanger = StartCoroutine(TakePosition());
    //}

    //private IEnumerator TakePosition()
    //{
    //    var waitTime = new WaitForEndOfFrame();

    //    while (parentTransform.position != targetPosition)
    //    {
    //        targetPosition = Target.position + positionIndent;
    //        parentTransform.position = Vector3.MoveTowards(parentTransform.position, targetPosition, speed * _speedBoost * Time.deltaTime);
    //        yield return waitTime;
    //    }

    //    if (parentTransform.position == targetPosition)
    //    {
    //        IsOnPosition = true;
    //        yield break;
    //    }
    //}
}
