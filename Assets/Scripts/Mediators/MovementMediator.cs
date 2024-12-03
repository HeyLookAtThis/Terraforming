using UnityEngine;
using Zenject;

public class MovementMediator : MonoBehaviour
{
    private Cloud _cloud;
    private Character _character;

    private CloudMovementBehaivorSwitcher _cloudMovementSwitcher;
    private CharacterStateMachine _characterStateMachine;

    private void OnDisable()
    {
        _characterStateMachine.JumpingState.EntryOnState -= OnSetMoveToTarget;
        _characterStateMachine.SitOnCloudState.EntryOnState -= OnSetMoveUnderTarget;
        _cloud.Reservoir.WaterIsOver -= OnSetMoveNearTarget;
        _cloud.Reservoir.WaterIsOver -= OnSwitchToFallingState;

        _cloud.Reservoir.RemoveActionCallback();
        _cloud.Resizer.RemoveActionCallback();
    }

    [Inject]
    public void Initialize(Character character, Cloud cloud)
    {
        _cloud = cloud;
        _character = character;

        _cloudMovementSwitcher = _cloud.MovementBehaivorSwitcher;
        _characterStateMachine = _character.StateMachine;

        _characterStateMachine.JumpingState.EntryOnState += OnSetMoveToTarget;
        _characterStateMachine.SitOnCloudState.EntryOnState += OnSetMoveUnderTarget;
        _cloud.Reservoir.WaterIsOver += OnSetMoveNearTarget;
        _cloud.Reservoir.WaterIsOver += OnSwitchToFallingState;

        _cloud.Reservoir.AddActionCallback();
        _cloud.Resizer.AddActionCallback();
    }

    private void OnSetMoveToTarget() => _cloudMovementSwitcher.SetMover<CloudToCharacterMover>();
    private void OnSetMoveUnderTarget() => _cloudMovementSwitcher.SetMover<WateringCloudMover>();
    private void OnSetMoveNearTarget() => _cloudMovementSwitcher.SetMover<EmptyCloudMover>();
    private void OnSwitchToFallingState() => _characterStateMachine.SwitchState<FallingState>();
}
