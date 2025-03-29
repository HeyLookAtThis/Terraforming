using UnityEngine;
using Zenject;

public class Arrow : MonoBehaviour
{
    [SerializeField] private ArrowView _view;

    private ITarget _character;
    private Transform _target;

    private Volcano _volcano;

    private float Speed => 10f;
    private float DistanceLengthProportion => 4f;

    private void OnEnable() => transform.position = _character.Transform.position;
    private void OnDisable() => _volcano.WasFrozen -= OnDeactivate;

    private void Update()
    {
        if (_target == null)
            return;

        Move();
        Rotate();
        Resize();
    }

    public void InitializeVolcano(Volcano volcano)
    {
        _volcano = volcano;
        _volcano.WasFrozen += OnDeactivate;
    }

    public void SetTarget(Transform target) => _target = target;
    public void Activate() => gameObject.SetActive(true);

    private void Move()
    {
        Vector3 position = _character.Transform.position + (_target.position - _character.Transform.position) / DistanceLengthProportion;
        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * Speed);
    }

    private void Rotate()
    {
        Vector3 direction = _target.position - _character.Transform.position;
        transform.forward = direction;
    }

    private void Resize()
    {
        float targetDistance = 5f;
        float distance = Vector3.Distance(_target.position, _character.Transform.position);
        Vector3 size = Vector3.one / targetDistance * distance;

        if (distance >= targetDistance)
            transform.localScale = Vector3.one;
        else
            transform.localScale = size;
    }

    private void OnDeactivate() => gameObject.SetActive(false);

    [Inject]
    private void Construct(ITarget character) => _character = character;
}
