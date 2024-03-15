using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(AudioListener))]
public class CameraMotion : MonoBehaviour
{
    [SerializeField] private Vector3 _interval;
    [SerializeField] private PlayerInstantiator _playerInstantiator;

    private AudioListener _listener;
    private Player _target;
    private float _speed = 3;

    private void Awake()
    {
        _listener = GetComponent<AudioListener>();
    }

    private void OnEnable()
    {
        _playerInstantiator.Created += OnInitialize;
    }

    private void OnDisable()
    {
        _playerInstantiator.Created -= OnInitialize;
    }

    private void Update()
    {
        if (_target != null)
            transform.DOMove(_target.transform.position + _interval, _speed * Time.deltaTime);
    }

    private void OnInitialize(Player player)
    {
        _listener.enabled = false;
        _target = player;
        transform.position = _target.transform.position + _interval;
    }
}
