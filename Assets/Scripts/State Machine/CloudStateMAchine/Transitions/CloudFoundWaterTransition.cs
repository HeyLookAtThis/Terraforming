using UnityEngine;

[RequireComponent(typeof(CloudScanner))]
public class CloudFoundWaterTransition : Transition
{
    private void OnEnable()
    {
        GetComponent<CloudScanner>().FoundWater += TurnOnNeedTransit;
    }

    private void OnDisable()
    {
        GetComponent<CloudScanner>().FoundWater -= TurnOnNeedTransit;
    }
}