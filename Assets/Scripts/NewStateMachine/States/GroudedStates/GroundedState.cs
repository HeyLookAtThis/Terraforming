public class GroundedState : MovementState
{
    private CharacterLayerChecker _characterLayerChecker;

    public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    => _characterLayerChecker = character.ColliderChecker;

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

    public override void Update()
    {
        base.Update();

        if (_characterLayerChecker.IsGrounded == false)
            StateSwitcher.SwitchState<FallingState>();

        if (_characterLayerChecker.IsInWater == true)
            StateSwitcher.SwitchState<JumpingState>();
    }
}
