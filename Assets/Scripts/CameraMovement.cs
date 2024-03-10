using DG.Tweening;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    [SerializeField] private Vector3 _interval;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private Player _target;

    private float _speed = 10;

    private void OnEnable()
    {
        _levelGenerator.Launched += TakeTargetPosition;
    }

    private void OnDisable()
    {
        _levelGenerator.Launched -= TakeTargetPosition;
    }

    private void Update()
    {
        transform.DOMove(_target.transform.position + _interval, _speed * Time.deltaTime);
    }

    private void TakeTargetPosition(uint currentLevel)
    {
        transform.position = _target.transform.position + _interval;
    }
}
