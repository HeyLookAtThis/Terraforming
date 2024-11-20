using UnityEngine;

public class CloudMovementMediator : MonoBehaviour
{
    [SerializeField] private Cloud _cloud;
    [SerializeField] private Character _character;

    private CloudMovementBehaivorSwitcher _cloudMovementSwitcher;
    private CharacterStateMachine _characterStateMachine;

    private void Awake()
    {
        _cloudMovementSwitcher = new(_cloud, _character.transform);
        _characterStateMachine = new(_character);

        _cloudMovementSwitcher.SetMover<WateringCloudMover>();
        _characterStateMachine.SwitchState<SitOnCloudState>();
    }

    private void OnEnable()
    {
        //_cloudMovementSwitcher.WateringCloudMover.WaterIsOver += _characterStateMachine.SitOnCloudState.OnSwitchToFallingState;
    }

    private void OnDisable()
    {
        
    }

    private void Update()
    {
        _characterStateMachine.HandleInput();
        _characterStateMachine.Update();
        _cloudMovementSwitcher.CurrentMover.Update(Time.deltaTime);
    }
}
