using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(CharacterColliderChecker))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterConfig _config;
    [SerializeField] private CharacterView _view;
    [SerializeField] private CameraDirectionIndicator _directionIndicator;

    private PlayerInput _input;
    private CharacterController _controller;
    private CharacterStateMachine _stateMachine;
    private CharacterColliderChecker _coliderChecker;

    public PlayerInput Input => _input;
    public CharacterView View => _view;
    public CharacterConfig Config => _config;
    public CharacterController Controller => _controller;
    public CharacterStateMachine StateMachine => _stateMachine;
    public CharacterColliderChecker ColliderChecker => _coliderChecker;
    public CameraDirectionIndicator DirectionIndicator => _directionIndicator;

    private void Awake()
    {
        _coliderChecker = GetComponent<CharacterColliderChecker>();
        _controller = GetComponent<CharacterController>();
        _view.Initialize();
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
