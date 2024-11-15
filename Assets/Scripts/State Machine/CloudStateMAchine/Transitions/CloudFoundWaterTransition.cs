using UnityEngine;

[RequireComponent(typeof(OldCloud))]
public class CloudFoundWaterTransition : Transition
{
    private void OnEnable()
    {
        GetComponent<OldCloud>().PlayerColliderChecker.FoundWater += TurnOnNeedTransit;
    }

    private void OnDisable()
    {
        GetComponent<OldCloud>().PlayerColliderChecker.FoundWater -= TurnOnNeedTransit;
    }
}