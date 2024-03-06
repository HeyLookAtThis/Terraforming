using UnityEngine;

public class LootView : ActiveObject
{
    [SerializeField] private AudioClip _sound;
    [SerializeField] private GameObject _model;

    private AudioSource _audioSourse;
    private ParticleSystem _effect;

    public bool IsAllowed => _model.activeSelf;

    public bool IsSoundPlaying => _audioSourse.isPlaying;

    protected override void Awake()
    {
        base.Awake();
        _audioSourse = GetComponentInChildren<AudioSource>();
        _effect = GetComponentInChildren<ParticleSystem>();

        _audioSourse.clip = _sound;

        ReturnToDefaultState();
        _effect.Stop();
    }

    public override void ReactToScanner(Player player)
    {
        TurnOnVisible();
    }

    public override void ReactToTree()
    {
        TurnOnVisible();
    }

    public override void ReturnToDefaultState()
    {
        _audioSourse.playOnAwake = false;
        _audioSourse.loop = false;
        gameObject.isStatic = false;
        _effect.Stop();

        _model.SetActive(false);
    }

    public void PlaySound()
    {
        _audioSourse.Play();
    }

    private void TurnOnVisible()
    {
        if (!(_model.activeSelf && WasUsedByPlayer))
        {
            _model.SetActive(true);
            _effect.Play();
        }
    }
}
