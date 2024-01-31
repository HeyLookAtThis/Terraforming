using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationsController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _movement.Falling += PlayIdle;
        _movement.Sitting += PlaySitting;
        _movement.Running += SetSpeed;
    }

    private void OnDisable()
    {
        _movement.Falling -= PlayIdle;
        _movement.Sitting -= PlaySitting;
        _movement.Running -= SetSpeed;
    }

    private void PlayIdle()
    {
        _animator.Play(PlayerAnimationController.Stats.Idle);
    }

    private void PlaySitting()
    {
        _animator.Play(PlayerAnimationController.Stats.Sitting);
    }

    private void SetSpeed(float speed)
    {
        _animator.SetFloat(PlayerAnimationController.Params.Speed, speed);
    }
}