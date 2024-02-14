public class PlayerFoundWaterTransition : Transition
{
    private void OnEnable()
    {
        GetComponent<PlayerColliderChecker>().FoundWater += TurnOnNeedTransit;
    }

    private void OnDisable()
    {
        GetComponent<PlayerColliderChecker>().FoundWater -= TurnOnNeedTransit;
    }
}
