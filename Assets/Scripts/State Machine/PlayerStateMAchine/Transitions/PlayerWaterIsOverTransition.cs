using UnityEngine;

public class PlayerWaterIsOverTransition : Transition
{
    private CloudReservoir _cloudReservoir;

    private void OnEnable()
    {
        if (_cloudReservoir != null)
            _cloudReservoir.WaterIsOver += TurnOnNeedTransit;
    }

    private void OnDisable()
    {
        _cloudReservoir.WaterIsOver -= TurnOnNeedTransit;
    }

    public void InitializeReservoir(CloudReservoir reservoir)
    {
        _cloudReservoir = reservoir;
        _cloudReservoir.WaterIsOver += TurnOnNeedTransit;
    }
}
