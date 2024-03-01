using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LootView : InteractionObject
{
    //[SerializeField] private ParticleSystem _effect;
    //[SerializeField] private AudioClip _sound;
    [SerializeField] private GameObject _model;

    private AudioSource _audioSourse;

    public bool IsAllowed => _model.activeSelf;

    protected override void Awake()
    {
        base.Awake();
        _audioSourse = GetComponent<AudioSource>();

        //_audioSourse.clip = _sound;
        _audioSourse.playOnAwake = false;
        _audioSourse.loop = false;
        gameObject.isStatic = false;

        _model.SetActive(false);
        //_effect.Stop();
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
        _audioSourse?.Play();
    }

    private void TurnOnVisible()
    {
        if (!(_model.activeSelf && WasUsedByPlayer))
        {
            _model.SetActive(true);
            //_effect.Play();
        }
    }
}
