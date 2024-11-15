public class RunningState : MovementState
{
    private readonly RunningStateConfig _config;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.RunningStateConfig;
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.Speed;
        Data.TimeToReachTargetRotation = _config.TimeToReachTargetRotation;

        CharacterView.StartRunning();
    }

    public override void Exit()
    {
        base.Exit();

        CharacterView.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (IsInputDirectionZero())
            StateSwitcher.SwitchState<IdilingState>();
    }
}
