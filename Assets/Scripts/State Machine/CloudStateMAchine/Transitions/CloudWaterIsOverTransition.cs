using UnityEngine;

[RequireComponent(typeof(CloudReservoir))]
public class CloudWaterIsOverTransition : Transition
{
    private void OnEnable()
    {
        GetComponent<CloudReservoir>().WaterIsOver += TurnOnNeedTransit;
    }

    private void OnDisable()
    {
        GetComponent<CloudReservoir>().WaterIsOver -= TurnOnNeedTransit;
    }
}