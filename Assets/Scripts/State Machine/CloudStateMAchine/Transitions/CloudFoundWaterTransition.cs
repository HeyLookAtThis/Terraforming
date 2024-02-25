using UnityEngine;

[RequireComponent(typeof(Cloud))]
public class CloudFoundWaterTransition : Transition
{
    private void OnEnable()
    {
        GetComponent<Cloud>().PlayerColliderChecker.FoundWater += TurnOnNeedTransit;
    }

    private void OnDisable()
    {
        GetComponent<Cloud>().PlayerColliderChecker.FoundWater -= TurnOnNeedTransit;
    }
}