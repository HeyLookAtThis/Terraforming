using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
    private Animator _animator;

    private void Awake() => _animator = GetComponent<Animator>();

    public void StartIdiling() => _animator.SetBool(CharacterAnimator.Params.IsIdiling, true);
    public void StopIdiling() => _animator.SetBool(CharacterAnimator.Params.IsIdiling, false);

    public void StartRunning() => _animator.SetBool(CharacterAnimator.Params.IsRunning, true);
    public void StopRunning() => _animator.SetBool(CharacterAnimator.Params.IsRunning, false);
}
