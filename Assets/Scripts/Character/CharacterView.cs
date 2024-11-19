using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
    private Animator _animator;

    public void Initialize() => _animator = GetComponent<Animator>();

    public void StartIdiling() => _animator.SetBool(CharacterAnimator.Params.IsIdiling, true);
    public void StopIdiling() => _animator.SetBool(CharacterAnimator.Params.IsIdiling, false);

    public void StartRunning() => _animator.SetBool(CharacterAnimator.Params.IsRunning, true);
    public void StopRunning() => _animator.SetBool(CharacterAnimator.Params.IsRunning, false);

    public void StartJumping() => _animator.SetBool(CharacterAnimator.Params.IsJumping, true);
    public void StopJumping() => _animator.SetBool(CharacterAnimator.Params.IsJumping, false);

    public void StartFalling() => _animator.SetBool(CharacterAnimator.Params.IsFalling, true);
    public void StopFalling() => _animator.SetBool(CharacterAnimator.Params.IsFalling, false);

    public void StartSitOnCloud() => _animator.SetBool(CharacterAnimator.Params.IsSitOnCloud, true);
    public void StopSitOnCloud() => _animator.SetBool(CharacterAnimator.Params.IsSitOnCloud, false);

    public void StartGrounded() => _animator.SetBool(CharacterAnimator.Params.IsGrounded, true);
    public void StopGrounded() => _animator.SetBool(CharacterAnimator.Params.IsGrounded, false);

    public void StartAirborne() => _animator.SetBool(CharacterAnimator.Params.IsAirborne, true);
    public void StopAirborne() => _animator.SetBool(CharacterAnimator.Params.IsAirborne, false);

    public void StartMovement() => _animator.SetBool(CharacterAnimator.Params.IsMovement, true);
    public void StopMovement() => _animator.SetBool(CharacterAnimator.Params.IsMovement, false);
}
