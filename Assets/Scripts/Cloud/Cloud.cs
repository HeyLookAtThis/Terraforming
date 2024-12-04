using UnityEngine;
using Zenject;

public class Cloud : MonoBehaviour
{
    [SerializeField] private CloudConfig _config;

    private CloudMovementBehaivorSwitcher _movementBehaivorSwitcher;

    private GrassPainter _grassPainter;
    private Reservoir _reservoir;
    private Resizer _resizer;
    private Scanner _scanner;

    private IMover _mover;

    public CloudMovementBehaivorSwitcher MovementBehaivorSwitcher => _movementBehaivorSwitcher;
    public GrassPainter GrassPainter => _grassPainter;
    public Reservoir Reservoir => _reservoir;
    public Resizer Resizer => _resizer;
    public CloudConfig Config => _config;
    public Scanner Scanner => _scanner;

    private void Update()
    {
        if (_mover is WateringCloudMover)
        {
            _grassPainter.Draw(transform.position, _config.CloudWateringConfig.GrassPainterRadius);
            _scanner.Update();
        }

        _mover?.Update(Time.deltaTime);
    }

    public void SetMover(IMover mover)
    {
        _mover?.StopMove();
        _mover = mover;
        _mover.StartMove();
    }

    [Inject]
    private void Construct(ITarget character, Terrain terrain, LevelBoundariesMarker levelBoundariesMarker, GrassPainter grassPainter)
    {
        _movementBehaivorSwitcher = new CloudMovementBehaivorSwitcher(this, character.Transform);
        _grassPainter = grassPainter;
        _scanner = new Scanner(this);
        _reservoir = new Reservoir(this);
        _resizer = new Resizer(this);
    }
}
