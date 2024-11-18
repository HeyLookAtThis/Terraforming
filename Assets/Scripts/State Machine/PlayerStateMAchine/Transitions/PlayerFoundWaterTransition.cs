public class PlayerFoundWaterTransition : Transition
{
    private void OnEnable()
    {
        GetComponent<CharacterColliderChecker>().FoundWater += TurnOnNeedTransit;
    }

    private void OnDisable()
    {
        GetComponent<CharacterColliderChecker>().FoundWater -= TurnOnNeedTransit;
    }
}
