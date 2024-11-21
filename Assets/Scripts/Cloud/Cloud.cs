using UnityEngine;
using UnityEngine.Events;

public class Cloud : MonoBehaviour
{
    [SerializeField] private float _wateringTime;
    [SerializeField] private CloudConfig _config;

    private CloudMovementBehaivorSwitcher _movementBehaivorSwitcher;

    private IMover _mover;
    private float _currentWateringTime;
    private UnityAction _waterIsOver;

    public event UnityAction WaterIsOver
    {
        add => _waterIsOver += value;
        remove => _waterIsOver -= value;
    }

    public CloudMovementBehaivorSwitcher MovementBehaivorSwitcher => _movementBehaivorSwitcher;
    public CloudConfig Config => _config;

    private void Awake()
    {
        _currentWateringTime = _wateringTime;
    }

    private void Update()
    {
        if (_mover is WateringCloudMover)
        {
            _currentWateringTime -= Time.deltaTime;

            if (_currentWateringTime <= 0)
            {
                _waterIsOver?.Invoke();
                _currentWateringTime = _wateringTime;
            }
        }

        _mover?.Update(Time.deltaTime);
    }

    public void SetMover(IMover mover)
    {
        _mover?.StopMove();
        _mover = mover;
        _mover.StartMove();
    }

    public void InitializeMovementSwithcer(Transform target) => _movementBehaivorSwitcher = new(this, target);
}
