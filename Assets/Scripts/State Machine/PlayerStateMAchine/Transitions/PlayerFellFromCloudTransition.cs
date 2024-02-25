using UnityEngine;

public class PlayerFellFromCloudTransition : Transition
{
    [SerializeField] private CloudReservoir _cloudReservoir;

    private void OnEnable()
    {
        _cloudReservoir.WaterIsOver += TurnOnNeedTransit;
    }

    private void OnDisable()
    {
        _cloudReservoir.WaterIsOver -= TurnOnNeedTransit;
    }
}
