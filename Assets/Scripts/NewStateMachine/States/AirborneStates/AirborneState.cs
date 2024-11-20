using UnityEngine;

public class AirborneState : MovementState
{
    private float _baseGravity;

    public AirborneState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    => _baseGravity = character.Config.AirborneStateConfig.BaseGravity;

    public override void Enter()
    {
        base.Enter();
        CharacterView.StartAirborne();
    }

    public override void Exit()
    {
        base.Exit();
        CharacterView.StopAirborne();
    }

    protected void UseGravity() => Data.YVelocity -= _baseGravity * Time.deltaTime;

    protected void StopUseGravity() => Data.YVelocity = 0;
}
