public class IdilingState : GroundedState
{
    public IdilingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        CharacterView.StartIdiling();
    }

    public override void Exit()
    {
        base.Exit();

        CharacterView.StopIdiling();
    }

    public override void Update()
    {
        base.Update();

        if (IsInputDirectionZero())
            return;

        StateSwitcher.SwitchState<RunningState>();
    }
}
