using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerColliderChecker), typeof(CharacterController), typeof(PlayerMovement))]
public class PlayerFellFromCloudState : State
{
    [SerializeField] private ParticleSystem _follower;

    private float _gravityValue = -9.81f;
    private Vector3 _velosity;

    private PlayerColliderChecker _playerCollider;
    private PlayerMovement _movement;

    private UnityAction<float> _running;
    private UnityAction _falling;

    public event UnityAction<float> Running
    {
        add => _running += value;
        remove => _running -= value;
    }

    public event UnityAction Falling
    {
        add => _falling += value;
        remove => _falling -= value;
    }

    private void Awake()
    {
        _playerCollider = GetComponent<PlayerColliderChecker>();
        _movement = GetComponent<PlayerMovement>();
        _follower.Stop();
    }

    private void OnEnable()
    {
        _falling?.Invoke();
        StartCoroutine(TrailEffectActivator());
    }

    private void OnDisable()
    {
        _follower.Stop();
    }

    private void Update()
    {
        if (_playerCollider.IsGrounded && _movement.Direction != Vector3.zero)
            _running?.Invoke(_movement.Speed);
        else
            _running?.Invoke(0);
    }

    private void FixedUpdate()
    {
        UzeGravity();
    }

    private void UzeGravity()
    {
        if (_playerCollider.IsGrounded && _velosity.y < 0)
        {
            _velosity.y = 0;
            return;
        }

        _velosity.y += _gravityValue * Time.fixedDeltaTime;
        GetComponent<CharacterController>().Move(_velosity * Time.fixedDeltaTime);
    }

    private IEnumerator TrailEffectActivator()
    {
        while(!_playerCollider.IsGrounded)
            yield return null;

        _follower.Play();
        yield break;
    }
}
