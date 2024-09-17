using Unity.VisualScripting;
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
        Vector3 direction = GetConvertedDirection();
        Controller.Move(Data.Speed * Time.deltaTime * direction);
        Quaternion targetRotation = Quaternion.Euler(0, GetDirectionAngle(direction), 0);
        _character.transform.rotation = targetRotation;
        Debug.Log(targetRotation);
    }

    protected bool IsInputDirectionZero() => Data.InpudDirection == Vector2.zero;

    private Vector2 ReadInputDirection() => Input.Movement.Move.ReadValue<Vector2>();
    private Vector3 GetConvertedDirection() => new Vector3(Data.InpudDirection.x, 0, Data.InpudDirection.y);

    private float GetDirectionAngle(Vector3 direction)
    {
        float directionAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        if (directionAngle < 0)
            directionAngle += 360;

        return directionAngle;
    }

    private void Rotate()
    {

    }
}
