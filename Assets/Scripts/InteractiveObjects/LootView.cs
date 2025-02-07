using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LootView : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;
    [SerializeField] private GameObject _model;
    [SerializeField] private ParticleSystem _particles;

    private AudioSource _audioSourse;
    private Sequence _animation;

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

        Tween appearance = transform.DOScale(Vector3.one, duration).From(Vector3.zero).SetEase(Ease.InBounce);
        Tween rotation = transform.DORotate(new(0, 360, 0), duration, RotateMode.FastBeyond360);

        _animation.Append(appearance).Append(rotation).OnComplete(() => RunRotateAnimation());
    }

    private void RunDisapearance()
    {
        ResetAnimation();

        float duration = 0.5f;

        Tween appearance = transform.DOScale(Vector3.zero, duration);

        _animation.Append(appearance).OnComplete(() => _model.SetActive(false));
    }

    private void RunRotateAnimation()
    {
        ResetAnimation();

        float duration = 0.5f;
        float sizeMultiplier = 0.9f;

        Tween resize = transform.DOScale(sizeMultiplier, duration);
        Tween rotation = transform.DORotate(new(0, 90, 0), duration).SetEase(Ease.OutQuad);

        _animation.Append(resize).Join(rotation).SetLoops(-1, LoopType.Yoyo);
    }

    private void ResetAnimation()
    {
        _animation?.Kill();
        _animation = DOTween.Sequence();
    }
}
