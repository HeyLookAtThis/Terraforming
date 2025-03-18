using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class LootView : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;
    [SerializeField] private GameObject _model;
    [SerializeField] private ParticleSystem _particles;

    private AudioSource _audioSourse;
    private Sequence _animation;

    private UnityAction _turnedOn;

    public event UnityAction TurnedOn
    {
        add => _turnedOn += value;
        remove => _turnedOn -= value;
    }

    public bool IsAllowed => _model.activeSelf;

    private void Awake()
    {
        _audioSourse = GetComponent<AudioSource>();

        _audioSourse.clip = _sound;

        _audioSourse.playOnAwake = false;
        _audioSourse.loop = false;
    }

    public void TurnOnVisible()
    {
        if (_model.activeSelf == false)
        {
            _turnedOn?.Invoke();
            RunAppeareance();
            _particles.Play();
        }
    }

    public void TurnOffVisible()
    {
        _particles.Stop();
        RunDisapearance();
    }

    public void PlaySound() => _audioSourse.Play();

    private void RunAppeareance()
    {
        _model.SetActive(true);
        ResetAnimation();

        float duration = 0.5f;

        _animation.Append(transform.DOScale(Vector3.one, duration).From(Vector3.zero).SetEase(Ease.InBounce))
            .Append(transform.DORotate(new(0, 360, 0), duration, RotateMode.FastBeyond360))
            .OnComplete(() => RunRotateAnimation());
    }

    private void RunDisapearance()
    {
        ResetAnimation();

        float duration = 0.5f;

        _animation.Append(transform.DOScale(Vector3.zero, duration))
            .OnComplete(() => _model.SetActive(false));
    }

    private void RunRotateAnimation()
    {
        ResetAnimation();

        float duration = 0.5f;
        float sizeTargetSize = 1.1f;
        float localY = 0.1f;

        _animation.Append(transform.DOScale(sizeTargetSize, duration))
            .Join(transform.DOLocalMoveY(localY, duration)
            .SetEase(Ease.InOutSine)).SetLoops(-1, LoopType.Yoyo);
    }

    private void ResetAnimation()
    {
        _animation?.Kill();
        _animation = DOTween.Sequence();
    }
}
