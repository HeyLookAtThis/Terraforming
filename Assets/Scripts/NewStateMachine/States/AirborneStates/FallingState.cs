public class FallingState : AirborneState
{
    private readonly CharacterColliderChecker _characterColliderChecker;

    public FallingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    => _characterColliderChecker = character.ColliderChecker;

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
        StartUseGravity();

        if (_characterColliderChecker.CheckGrounded())
        {
            if (IsInputDirectionZero())
                StateSwitcher.SwitchState<IdilingState>();
            else
                StateSwitcher.SwitchState<RunningState>();
        }
    }
}
