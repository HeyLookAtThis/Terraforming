using System.Collections;
using UnityEngine;

public class CloudNoWaterState : CloudState
{
    private void Awake()
    {
        positionIndent = Vector3.one;
    }

    private void Update()
    {
        targetPosition = Target.position + positionIndent;
        float speed = TargetSpeed * Vector3.Distance(targetPosition, transform.position) * SpeedBoost;

        Move(targetPosition, speed);
    }
}