using UnityEngine;
using Zenject;

public class MovementMediator : MonoBehaviour
{
    private Cloud _cloud;
    private Character _character;

    private CloudMovementBehaivorSwitcher _cloudMovementSwitcher;
    private CharacterStateMachine _characterStateMachine;

    private void Awake()
    {
        _cloudMovementSwitcher = _cloud.MovementBehaivorSwitcher;
        _characterStateMachine = _character.StateMachine;
    }

    private void OnEnable()
    {
        _characterStateMachine.JumpingState.EntryOnState += OnSetMoveToTarget;
        _characterStateMachine.SitOnCloudState.EntryOnState += OnSetMoveUnderTarget;
        _cloud.Resizer.WaterIsOver += OnSetMoveNearTarget;
        _cloud.Resizer.WaterIsOver += OnSwitchToFallingState;
    }

    private void OnDisable()
    {
        _characterStateMachine.JumpingState.EntryOnState -= OnSetMoveToTarget;
        _characterStateMachine.SitOnCloudState.EntryOnState -= OnSetMoveUnderTarget;
        _cloud.Resizer.WaterIsOver -= OnSetMoveNearTarget;
        _cloud.Resizer.WaterIsOver -= OnSwitchToFallingState;
    }

    [Inject]
    public void Construct(Character character, Cloud cloud)
    {
        _cloud = cloud;
        _character = character;
    }

    private void OnSetMoveToTarget() => _cloudMovementSwitcher.SetMover<CloudToCharacterMover>();
    private void OnSetMoveUnderTarget() => _cloudMovementSwitcher.SetMover<WateringCloudMover>();
    private void OnSetMoveNearTarget() => _cloudMovementSwitcher.SetMover<EmptyCloudMover>();
    private void OnSwitchToFallingState() => _characterStateMachine.SwitchState<FallingState>();
}
