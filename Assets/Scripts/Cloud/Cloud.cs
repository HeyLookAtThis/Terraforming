using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private CloudConfig _config;
    [SerializeField] private Terrain _terrain;

    private CloudMovementBehaivorSwitcher _movementBehaivorSwitcher;

    private GrassPainter _grassPainter;
    private Reservoir _reservoir;
    private Resizer _resizer;
    private Scanner _scanner;

    private IMover _mover;

    public CloudMovementBehaivorSwitcher MovementBehaivorSwitcher => _movementBehaivorSwitcher;
    public Reservoir Reservoir => _reservoir;
    public Resizer Resizer => _resizer;
    public CloudConfig Config => _config;
    public Scanner Scanner => _scanner;

    private void Update()
    {
        if (_mover is WateringCloudMover)
        {
            _grassPainter.Draw();

            if (_grassPainter.IsDrawing)
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

    public void Initialize(Transform target)
    {
        _movementBehaivorSwitcher = new CloudMovementBehaivorSwitcher(this, target);
        _grassPainter = new GrassPainter(_terrain, this);
        _scanner = new Scanner(this);
        _reservoir = new Reservoir(this);
        _resizer = new Resizer(this);
    }
}
