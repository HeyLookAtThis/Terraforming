using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ObjectSoundPlayer : MonoBehaviour
{
    [SerializeField] private float _maxDistance;
    [SerializeField] private AudioClip _sound;

    protected AudioSource source;

    private GameplayChecker _gameplayChecker;

    protected AudioClip sound => _sound;

    protected virtual void Awake()
    {
        source = GetComponent<AudioSource>();
        _gameplayChecker = GetComponentInParent<GameplayChecker>();

        source.clip = _sound;
        source.loop = true;
        source.playOnAwake = false;
        source.spatialBlend = 1;
        source.minDistance = 0;
        source.maxDistance = _maxDistance;
        source.rolloffMode = AudioRolloffMode.Linear;
    }

    protected virtual void OnEnable()
    {
        _gameplayChecker.Update += SetSoundPlayer;
    }

    protected virtual void OnDisable()
    {
        _gameplayChecker.Update -= SetSoundPlayer;
    }

    private void SetSoundPlayer(bool isGamePlaying)
    {
        if (isGamePlaying)
            source.Play();
        else
            source.Stop();
    }
}
