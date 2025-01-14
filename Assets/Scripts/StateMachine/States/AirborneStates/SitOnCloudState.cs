using UnityEngine.Events;

public class SitOnCloudState : AirborneState, IStateEntryAction
{
    private SitOnCloudConfig _config;

    public SitOnCloudState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    => _config = character.Config.AirborneStateConfig.SitOnCloudConfig;

    public event UnityAction EntryOnState;

    public override void Enter()
    {
        base.Enter();
        Data.Speed = _config.Speed;
        CharacterView.StartSitOnCloud();
        EntryOnState?.Invoke();
    }

    public override void Exit()
    {
        base.Exit();
        CharacterView.StopSitOnCloud();
    }

    public void OnSwitchToFallingState() => StateSwitcher.SwitchState<FallingState>();
}
