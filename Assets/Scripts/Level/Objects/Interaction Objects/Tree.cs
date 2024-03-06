using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Tree : ActiveObject
{
    [SerializeField] private float _radius;
    [SerializeField] private AudioClip _sound;
    [SerializeField] private GameObject _emptyTrunk;
    [SerializeField] private GameObject _greenTrunk;

    AudioSource _audioSource;
    private ParticleSystem _particleSystem;

    protected override void Awake()
    {
        base.Awake();

        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _audioSource = GetComponent<AudioSource>();

        _audioSource.clip = _sound;
        _particleSystem.Stop();
    }

    private void Start()
    {
        SetGreenModel(WasUsedByPlayer);
    }

    public override void ReactToScanner(Player player)
    {
        MakeGreen();
    }

    public override void ReactToTree()
    {
        MakeGreen();
    }

    public override void ReturnToDefaultState()
    {
        Destroy(gameObject);
    }

    private void MakeGreen()
    {
        if (WasUsedByPlayer == false)
        {
            TurnOnUsed();
            SetGreenModel(WasUsedByPlayer);
            UseObjectsAround();
            _audioSource.Play();
            _particleSystem.Play();
        }
    }

    public void SetGreenModel(bool isGreen)
    {
        _emptyTrunk.SetActive(!isGreen);
        _greenTrunk.SetActive(isGreen);
    }

    private void UseObjectsAround()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (var collider in colliders)
            if (collider.TryGetComponent<ActiveObject>(out ActiveObject interationObject))
                interationObject.ReactToTree();
    }
}