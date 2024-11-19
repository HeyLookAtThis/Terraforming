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
    protected CharacterView CharacterView => _character.View;
    protected Character Character => _character;

    public virtual void Enter()
    {
        AddActionsCallback();
        CharacterView.StartMovement();
    }

    public virtual void Exit()
    {
        RemoveActionsCallback();
        CharacterView.StopMovement();
    }

    public void HandleInput()
    {
        Data.InputDirection = ReadInputDirection();
    }

    public virtual void Update()
    {
        if (IsInputDirectionZero())
            return;

        Vector3 direction = GetConvertedDirection();
        float inputAngleDirection = GetDirectionAngle(direction);

        Controller.Move(Data.Speed * Time.deltaTime * direction);
        Rotate(inputAngleDirection);
    }

    protected virtual void AddActionsCallback() { }
    protected virtual void RemoveActionsCallback() { }
    protected bool IsInputDirectionZero() => Data.InputDirection == Vector2.zero;
    private Vector2 ReadInputDirection() => Input.Movement.Move.ReadValue<Vector2>();
    private Vector3 GetConvertedDirection()
    {
        Vector3 direction = _character.DirectionIndicator.transform.right * Data.InputDirection.x + _character.DirectionIndicator.transform.forward * Data.InputDirection.y;
        direction.y = Data.YVelocity;
        return direction;
    }

    private float GetDirectionAngle(Vector3 direction)
    {
        float directionAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        if (directionAngle < 0)
            directionAngle += 360;

        return directionAngle;
    }

    private void Rotate(float angle)
    {
        if(angle != Data.CurrentTargetRotation)
        {
            Data.CurrentTargetRotation = angle;
            Data.DampedTargetRotationPassedTime = 0;
        }

        RotateTowardsTargetRotation();
    }

    private void RotateTowardsTargetRotation()
    {
        float currentYAngle = _character.transform.rotation.eulerAngles.y;

        if (currentYAngle == Data.CurrentTargetRotation)
            return;

        float smoothedYAngle = Mathf.SmoothDampAngle(currentYAngle, Data.CurrentTargetRotation, ref Data.DampedTargetRotationCurrentVelocity, Data.TimeToReachTargetRotation - Data.DampedTargetRotationPassedTime);
        Data.DampedTargetRotationPassedTime += Time.deltaTime;

        Quaternion targetRotation = Quaternion.Euler(0, smoothedYAngle, 0);
        _character.transform.rotation = targetRotation;
    }
}
