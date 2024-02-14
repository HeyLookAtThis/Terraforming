public class PlayerFellFromCloudTransition : Transition
{
    private void OnEnable()
    {
        GetComponent<PlayerColliderChecker>().FellFromCloud += TurnOnNeedTransit;
    }

    private void OnDisable()
    {
        GetComponent<PlayerColliderChecker>().FellFromCloud -= TurnOnNeedTransit;
    }
}
