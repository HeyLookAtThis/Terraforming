using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class WaterDropView : MonoBehaviour
{
    [SerializeField] private float _pauseTime = 0.9f;
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _yOffset = 3.2f;

    private float _passedTime = 0;

    private ParticleSystem _particleSystem;

    private void Awake() => _particleSystem = GetComponent<ParticleSystem>();

    private void Update()
    {
        if (_particleSystem.isPaused)
            return;

        if (_particleSystem.isPlaying == false)
            _particleSystem.Play();

        _passedTime += Time.deltaTime;

        if (_passedTime >= _pauseTime)
        {
            _particleSystem.Pause();
            RunAnimation();
        }
    }

    private void RunAnimation() => transform.DOLocalMoveY(_yOffset, _animationDuration).SetLoops(-1, LoopType.Yoyo);
}
