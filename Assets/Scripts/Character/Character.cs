using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour, ITarget
{
    [SerializeField] private CharacterConfig _config;
    [SerializeField] private CharacterView _view;
    [SerializeField] private CharacterLayerChecker _coliderChecker;

    private PlayerInput _input;
    private CharacterController _controller;
    private CharacterStateMachine _stateMachine;
    private CameraDirectionIndicator _directionIndicator;

    public PlayerInput Input => _input;
    public CharacterView View => _view;
    public CharacterConfig Config => _config;
    public CharacterController Controller => _controller;
    public CharacterStateMachine StateMachine => _stateMachine;
    public CharacterLayerChecker ColliderChecker => _coliderChecker;
    public CameraDirectionIndicator DirectionIndicator => _directionIndicator;

    public Transform Transform => transform;

    private void OnDisable() => _input.Disable();

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    [Inject]
    private void Construct(CameraDirectionIndicator directionIndicator)
    {
        _controller = GetComponent<CharacterController>();
        _view.Initialize();

        _directionIndicator = directionIndicator;

        _input = new PlayerInput();
        _input.Enable();

        _stateMachine = new CharacterStateMachine(this);
    }
}
