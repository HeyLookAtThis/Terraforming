using UnityEngine;
using Zenject;

public class TrailMediator : MonoBehaviour
{
    [SerializeField] private Arrow _arrow;

    private ITarget _character;
    private Transform _target;

    private void Update()
    {
        Vector3 position = (_target.position - _character.Transform.position) / 2;
        Move(position);

        transform.forward = _target.position - _character.Transform.position;
        float size = Vector3.Distance(_target.position, _character.Transform.position);
        transform.localScale = new Vector3(size, size, size);
    }

    private void Move(Vector3 position) => transform.Translate(position.x, transform.position.y, position.z);

    public void SetTarget(Transform target) => _target = target;

    [Inject]
    private void Construct(ITarget character, LevelBuilder levelBuilder)
    {
        _character = character;        
    }
}
