using UnityEngine;

public abstract class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;

    private readonly Character _character;

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _character = character;
    }

    protected PlayerInput Input => _character.Input;
    protected CharacterController Controller => _character.Controller;

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public void HandleInput()
    {
        Data.InpudDirection = ReadInputDirection();
    }

    public virtual void Update()
    {
        Controller.Move(Data.Speed * Time.deltaTime * GetConvertedDirection());
    }

    protected bool IsInputDirectionZero() => Data.InpudDirection == Vector2.zero;

    private Vector2 ReadInputDirection() => Input.Movement.Move.ReadValue<Vector2>();
    private Vector3 GetConvertedDirection() => new Vector3(Data.InpudDirection.x, 0, Data.InpudDirection.y);
}
