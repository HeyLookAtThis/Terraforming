using UnityEngine;

public class MovementMediator : MonoBehaviour
{
    [SerializeField] private Cloud _cloud;
    [SerializeField] private Character _character;

    private CloudMovementBehaivorSwitcher _cloudMovementSwitcher;
    private CharacterStateMachine _characterStateMachine;

    private void Awake()
    {
        _cloud.InitializeMovementSwithcer(_character.transform);

        _cloudMovementSwitcher = _cloud.MovementBehaivorSwitcher;
        _characterStateMachine = _character.StateMachine;
    }

    private void OnEnable()
    {
        _characterStateMachine.JumpingState.EntryOnState += OnSetMoveToTarget;
        _characterStateMachine.SitOnCloudState.EntryOnState += OnSetMoveUnderTarget;
        _cloud.WaterIsOver += OnSetMoveNearTarget;
        _cloud.WaterIsOver += OnSwitchToFallingState;
    }

    private void OnDisable()
    {
        _characterStateMachine.JumpingState.EntryOnState -= OnSetMoveToTarget;
        _characterStateMachine.SitOnCloudState.EntryOnState -= OnSetMoveUnderTarget;
        _cloud.WaterIsOver -= OnSetMoveNearTarget;
        _cloud.WaterIsOver -= OnSwitchToFallingState;
    }

    private void OnSetMoveToTarget() => _cloudMovementSwitcher.SetMover<CloudToCharacterMover>();
    private void OnSetMoveUnderTarget() => _cloudMovementSwitcher.SetMover<WateringCloudMover>();
    private void OnSetMoveNearTarget() => _cloudMovementSwitcher.SetMover<EmptyCloudMover>();
    private void OnSwitchToFallingState() => _characterStateMachine.SwitchState<FallingState>();

}
