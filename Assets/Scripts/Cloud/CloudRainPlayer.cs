using System.Collections;
using UnityEngine;

public class CloudRainPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private ParticleSystem _particles;

    private AudioSource _audioSource;
    private Coroutine _rainBegginer;
    private CloudScanner _scanner;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _scanner = GetComponentInParent<CloudScanner>();

        _audioSource.loop = true;
        _audioSource.playOnAwake = false;
        _audioSource.Stop();
        _particles.Stop();
    }

    private void OnEnable()
    {
        _scanner.FoundInteractionObject += StartRain;
    }

    private void OnDisable()
    {
        _scanner.FoundInteractionObject -= StartRain;
    }

    private void StartRain()
    {
        if (_rainBegginer != null)
            StopCoroutine(_rainBegginer);

        _rainBegginer = StartCoroutine(Rain());
    }

    private IEnumerator Rain()
    {
        float duration = 0.3f;
        float seconds = 0.05f;
        var waitTime = new WaitForSeconds(seconds);

        float secondsCounter = 0f;

        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
            _particles.Play();
        }

        while (secondsCounter < duration)
        {
            secondsCounter += seconds;
            yield return waitTime;
        }

        if (secondsCounter >= duration || !_scanner.IsActivated)
        {
            _audioSource.Pause();
            _particles.Stop();
            yield break;
        }
    }
}