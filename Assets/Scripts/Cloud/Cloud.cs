using UnityEngine;
using Zenject;

public class Cloud : MonoBehaviour
{
    [SerializeField] private CloudConfig _config;
    [SerializeField] private CloudView _view;

    private CloudMovementBehaivorSwitcher _movementBehaivorSwitcher;

    private GrassPainter _grassPainter;
    private Scanner _scanner;

    private IMover _mover;

    public CloudMovementBehaivorSwitcher MovementBehaivorSwitcher => _movementBehaivorSwitcher;
    public GrassPainter GrassPainter => _grassPainter;
    public Resizer Resizer => _view.Resizer;
    public CloudConfig Config => _config;
    public Scanner Scanner => _scanner;

    private void Awake() => _scanner = new Scanner(this, _movementBehaivorSwitcher.WateringCloudMover);
    private void OnEnable() => _movementBehaivorSwitcher.WateringCloudMover.Updated += OnRunDrawer;
    private void OnDisable() => _movementBehaivorSwitcher.WateringCloudMover.Updated -= OnRunDrawer;
    private void Update() => _mover?.Update(Time.deltaTime);

    [Inject]
    private void Construct(ITarget character, GrassPainter grassPainter)
    {
        _movementBehaivorSwitcher = new CloudMovementBehaivorSwitcher(this, character.Transform);
        _grassPainter = grassPainter;
    }

    public void SetDefaultState() => _view.SetDefaultState();

    public void SetMover(IMover mover)
    {
        _mover?.StopMove();
        _mover = mover;
        _mover.StartMove();
    }

    private void OnRunDrawer()
    {
        _grassPainter.Draw(transform.position, _config.CloudWateringConfig.GrassPainterRadius, this);
        _scanner.Update();
    }
}
