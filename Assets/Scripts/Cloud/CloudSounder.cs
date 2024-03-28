using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class CloudSounder : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private ParticleSystem _particles;

    private AudioSource _audioSource;
    private Coroutine _runner;

    private CloudScanner _scanner;

    protected CloudScanner scanner => _scanner;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _scanner = GetComponentInParent<CloudScanner>();

        _audioSource.loop = true;
        _audioSource.playOnAwake = false;
        _audioSource.Stop();
        _particles.Stop();
    }

    protected virtual void Run()
    {
        _audioSource.clip = _audioClip;

        if (_runner != null)
            StopCoroutine(_runner);

        _runner = StartCoroutine(Rain());
    }

    private IEnumerator Rain()
    {
        float duration = 0.3f;
        float seconds = 0.05f;
        float secondsCounter = 0f;

        var waitTime = new WaitForSecondsRealtime(seconds);

        if (!_audioSource.isPlaying)
        {
            _audioSource?.Play();
            _particles.Play();
        }

        while (secondsCounter < duration)
        {
            secondsCounter += seconds;
            yield return waitTime;
        }

        if (secondsCounter >= duration || !_scanner.IsActivated)
        {
            _audioSource?.Pause();
            _particles.Stop();
            yield break;
        }
    }
}
