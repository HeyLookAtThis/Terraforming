using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    private PlayerInput _input;
    private CharacterController _controller;
    private CharacterStateMachine _stateMachine;

    public PlayerInput Input => _input;
    public CharacterController Controller => _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _input = new();
        _stateMachine = new(this);
    }

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }
}
