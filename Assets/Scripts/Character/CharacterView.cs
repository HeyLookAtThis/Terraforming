using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public class CharacterView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _stepEffect;
    [SerializeField] private AudioClip[] _steps;

    private Animator _animator;
    private AudioSource _audioSource;
    private Coroutine _stepsPlayer;

    private bool _isNeedPlaySound;

    private void Awake()
    {
        _stepEffect.Stop();
    }

    public void Initialize()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartIdiling() => _animator.SetBool(CharacterAnimator.Params.IsIdiling, true);
    public void StopIdiling() => _animator.SetBool(CharacterAnimator.Params.IsIdiling, false);

    public void StartRunning()
    {
        _animator.SetBool(CharacterAnimator.Params.IsRunning, true);
        StartPlaySteps();
        _stepEffect.Play();
    }
    public void StopRunning()
    {
        _animator.SetBool(CharacterAnimator.Params.IsRunning, false);
        StopPlaySteps();
        _stepEffect.Stop();
    }

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

    private void StartPlaySteps()
    {
        _isNeedPlaySound = true;
        _stepsPlayer = StartCoroutine(StepsSoundSwitcher());
    }

    private void StopPlaySteps()
    {
        _isNeedPlaySound = false;

        if (_stepsPlayer != null)
            StopCoroutine(StepsSoundSwitcher());
    }

    private IEnumerator StepsSoundSwitcher()
    {
        while (_isNeedPlaySound)
        {
            if (_audioSource.isPlaying == false)
                PlayRandomStepSound();

            yield return null;
        }

        if (_isNeedPlaySound == false)
        {
            _audioSource.Stop();
            yield break;
        }
    }

    private void PlayRandomStepSound()
    {
        _audioSource.clip = _steps[Random.Range(0, _steps.Length - 1)];
        _audioSource.Play();
    }
}
