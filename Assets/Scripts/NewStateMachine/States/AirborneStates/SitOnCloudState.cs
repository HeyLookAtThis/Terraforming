using UnityEngine;

public class SitOnCloudState : AirborneState
{
    private SitOnCloudConfig _config;
    private float _timeOnCloud;

    public SitOnCloudState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    => _config = character.Config.AirborneStateConfig.SitOnCloudConfig;

    public override void Enter()
    {
        base.Enter();
        Data.Speed = _config.Speed;
        _timeOnCloud = 5;
        CharacterView.StartSitOnCloud();
    }

    public override void Exit()
    {
        base.Exit();
        CharacterView.StopSitOnCloud();
    }

    public override void Update()
    {
        base.Update();
        _timeOnCloud -= Time.deltaTime;

        if (_timeOnCloud <= 0)
            StateSwitcher.SwitchState<FallingState>();
    }
}
