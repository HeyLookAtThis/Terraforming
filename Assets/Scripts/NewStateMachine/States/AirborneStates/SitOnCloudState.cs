public class SitOnCloudState : AirborneState
{
    private SitOnCloudConfig _config;

    public SitOnCloudState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    => _config = character.Config.AirborneStateConfig.SitOnCloudConfig;

    public override void Enter()
    {
        base.Enter();
        Data.Speed = _config.Speed;
        CharacterView.StartSitOnCloud();
    }

    public override void Exit()
    {
        base.Exit();
        CharacterView.StopSitOnCloud();
    }

    public void OnSwitchToFallingState() => StateSwitcher.SwitchState<FallingState>();
}
