public class JumpingState : AirborneState
{
    private JumpingStateConfig _config;

    public JumpingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    => _config = character.Config.AirborneStateConfig.JumpingStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.YVelocity = _config.StartYVelocity;
        CharacterView.StartJumping();
    }

    public override void Exit()
    {
        base.Exit();
        StopUseGravity();
        CharacterView.StopJumping();
    }

    public override void Update()
    {
        base.Update();
        UseGravity();

        if (Data.YVelocity < 0)
            StateSwitcher.SwitchState<SitOnCloudState>();
    }
}
