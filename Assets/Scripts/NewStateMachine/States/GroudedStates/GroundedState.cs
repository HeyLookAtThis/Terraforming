public class GroundedState : MovementState
{
    public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    protected override void AddActionsCallback()
    {
        base.AddActionsCallback();
        Character.PlayerColliderChecker.FoundWater += OnFoundWater;
    }


    protected override void RemoveActionsCallback()
    {
        base.RemoveActionsCallback();
        Character.PlayerColliderChecker.FoundWater -= OnFoundWater;
    }

    private void OnFoundWater() => StateSwitcher.SwitchState<JumpingState>();
}
