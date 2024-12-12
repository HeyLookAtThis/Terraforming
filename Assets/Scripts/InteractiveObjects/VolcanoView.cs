using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VolcanoView : MonoBehaviour
{
    [SerializeField] private float _soundDistance;
    [SerializeField] private AudioClip _freezeSound;
    [SerializeField] private AudioClip _soundAround;

    [SerializeField] private ParticleSystem _smokeEffect;
    [SerializeField] private ParticleSystem _freezEffect;
    [SerializeField] private Volcano _volcano;
    
    private AudioSource _source;
    private Coroutine _freezer;

    private float MinValueOfSpatialBlend => 0f;
    private float MaxValueOfSpatialBlend => 1f;

    private void Awake()
    {
        _source = GetComponentInChildren<AudioSource>();
        Initialize();
    }

    public void Freeze()
    {
        _source.loop = false;
        _source.spatialBlend = MinValueOfSpatialBlend;
        _source.clip = _freezeSound;

        _smokeEffect.Stop();
        RunFreezer();
    }

    private void Initialize()
    {
        _source.clip = _soundAround;
        _source.loop = true;
        _source.spatialBlend = MaxValueOfSpatialBlend;
        _source.minDistance = 0;
        _source.maxDistance = _soundDistance;
        _source.rolloffMode = AudioRolloffMode.Linear;
        _source.Play();

        _smokeEffect.Play();
        _freezEffect.Stop();
    }

    private void RunFreezer()
    {
        if (_freezer != null)
            StopCoroutine(_freezer);

        _freezer = StartCoroutine(Freezer());
    }

    private IEnumerator Freezer()
    {
        _freezEffect.Play();
        _source.Play();

        while (_source.isPlaying)
            yield return null;

        if (_source.isPlaying == false)
        {
            _volcano.gameObject.SetActive(false);
            yield break;
        }
    }
}
