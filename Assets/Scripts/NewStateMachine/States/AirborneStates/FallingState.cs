public class FallingState : AirborneState
{
    private readonly CharacterLayerChecker _characterColliderChecker;

    public FallingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    => _characterColliderChecker = character.ColliderChecker;

    protected override void AddActionsCallback()
    {
        base.AddActionsCallback();
        _characterColliderChecker.Grounded += OnGoToGroundedState;
        _characterColliderChecker.FoundWater += OnGoToJumpingState;
    }

    protected override void RemoveActionsCallback()
    {
        base.RemoveActionsCallback();
        _characterColliderChecker.Grounded -= OnGoToGroundedState;
        _characterColliderChecker.FoundWater -= OnGoToJumpingState;
    }

    public override void Enter()
    {
        base.Enter();
        CharacterView.StartFalling();
    }

    public override void Exit()
    {
        base.Exit();
        StopUseGravity();
        CharacterView.StopFalling();
    }

    public override void Update()
    {
        base.Update();
        UseGravity();
    }

    private void OnGoToGroundedState()
    {
        if (IsInputDirectionZero())
            StateSwitcher.SwitchState<IdilingState>();
        else
            StateSwitcher.SwitchState<RunningState>();
    }

    private void OnGoToJumpingState() => StateSwitcher.SwitchState<JumpingState>();
}
