public class GroundedState : MovementState
{
    private CharacterColliderChecker _characterColliderChecker;

    public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    => _characterColliderChecker = character.ColliderChecker;

    protected override void AddActionsCallback()
    {
        base.AddActionsCallback();
        _characterColliderChecker.FoundWater += OnFoundWater;
    }


    protected override void RemoveActionsCallback()
    {
        base.RemoveActionsCallback();
        _characterColliderChecker.FoundWater -= OnFoundWater;
    }

    public override void Enter()
    {
        base.Enter();
        CharacterView.StartGrounded();
    }

    public override void Exit()
    {
        base.Exit();
        CharacterView.StopGrounded();
    }

    private void OnFoundWater() => StateSwitcher.SwitchState<JumpingState>();
}
