using System.Collections;
using UnityEngine;

public class CloudNoWaterState : CloudState
{
    private Coroutine _positionChanger;

    private float _indent;
    private float _speed;

    private void Start()
    {
        _indent = 2f;
        positionIndent.y = _indent;
    }

    private void Update()
    {
        targetPosition = Target.position + positionIndent;
        _speed = Speed * Vector3.Distance(targetPosition, transform.position) / _indent;

        Move(targetPosition);
    }

    public override void Enter()
    {
        base.Enter();
        BeginChangePosition();
    }

    private void BeginChangePosition()
    {
        if (_positionChanger != null)
            StopCoroutine(_positionChanger);

        _positionChanger = StartCoroutine(TakePosition());
    }

    private IEnumerator TakePosition()
    {
        var waitTime = new WaitForEndOfFrame();

        while (transform.position != targetPosition)
        {
            targetPosition = Target.position + positionIndent;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
            yield return waitTime;
        }

        if (transform.position == targetPosition)
            yield break;
    }
}