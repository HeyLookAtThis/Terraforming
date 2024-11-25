using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private CloudConfig _config;
    [SerializeField] private Terrain _terrain;

    private CloudMovementBehaivorSwitcher _movementBehaivorSwitcher;
    private GrassPainter _grassPainter;
    private Reservoir _reservoir;
    private IMover _mover;

    public CloudMovementBehaivorSwitcher MovementBehaivorSwitcher => _movementBehaivorSwitcher;
    public Reservoir Reservoir => _reservoir;
    public CloudConfig Config => _config;

    private void Update()
    {
        if (_mover is WateringCloudMover)
        {
            _grassPainter.Draw();
            _reservoir.Update();
        }

        _mover?.Update(Time.deltaTime);
    }

    public void SetMover(IMover mover)
    {
        _mover?.StopMove();
        _mover = mover;
        _mover.StartMove();
    }

    public void Initialize(Transform target)
    {
        _movementBehaivorSwitcher = new CloudMovementBehaivorSwitcher(this, target);
        _grassPainter = new GrassPainter(_terrain, this, _config.CloudWateringConfig.Radius);
        _reservoir = new Reservoir(_config.CloudWateringConfig.WateringTime);
    }
}
