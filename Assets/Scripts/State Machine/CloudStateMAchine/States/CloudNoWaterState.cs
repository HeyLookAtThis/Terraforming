using System.Collections;
using UnityEngine;

public class CloudNoWaterState : CloudState
{
    private float _indent;

    private void Awake()
    {
        _indent = 0.5f;
        //positionIndent.y = _indent;
        positionIndent = Vector3.one;
        targetPosition = Target.position + positionIndent;
    }

    private void Update()
    {
        targetPosition = Target.position + positionIndent;
        speed = TargetSpeed * Vector3.Distance(targetPosition, transform.position) * _indent;

        Move(targetPosition);
    }
}