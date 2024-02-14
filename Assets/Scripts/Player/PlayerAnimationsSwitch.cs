using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationsController : MonoBehaviour
{
    private PlayerFellFromCloudState _playerFellFromCloudState;
    private PlayerSatOnCloudState _playerOnCloudState;
    private Animator _animator;

    private void Awake()
    {
        _playerFellFromCloudState = GetComponentInParent<PlayerFellFromCloudState>();
        _playerOnCloudState = GetComponentInParent<PlayerSatOnCloudState>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerFellFromCloudState.Falling += PlayIdle;
        _playerOnCloudState.SatOnCloud += PlaySitting;
        _playerFellFromCloudState.Running += SetSpeed;
    }

    private void OnDisable()
    {
        _playerFellFromCloudState.Falling -= PlayIdle;
        _playerOnCloudState.SatOnCloud -= PlaySitting;
        _playerFellFromCloudState.Running -= SetSpeed;
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