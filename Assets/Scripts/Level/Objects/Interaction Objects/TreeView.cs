using System.Collections;
using UnityEngine;
using UnityEngine.Device;

[RequireComponent(typeof(AudioSource))]
public class TreeView : MonoBehaviour
{
    [SerializeField] private float _soundDistance;
    [SerializeField] private AudioClip _growSound;
    [SerializeField] private AudioClip _soundAround;
    [SerializeField] private ParticleSystem _growEffect;
    [SerializeField] private GameObject _emptyTrunk;
    [SerializeField] private GameObject _greenTrunk;

    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _growEffect.Stop();
        Initialize();
    }

    public void MakeGreen()
    {
        _emptyTrunk.SetActive(false);
        _greenTrunk.SetActive(true);
        _growEffect.Play();
        PlaySound();
    }

    private void Initialize()
    {
        _source.clip = _growSound;
        _source.loop = false;
        _source.playOnAwake = false;

        _emptyTrunk.SetActive(true);
        _greenTrunk.SetActive(false);
    }

    private void PlaySound()
    {
        _source.clip = _growSound;
        _source.Play();

        StartCoroutine(SoundSwither());
    }

    private IEnumerator SoundSwither()
    {
        while (_source.isPlaying)
        {
            yield return null;
        }

        if(_source.isPlaying == false)
        {
            _source.clip = _soundAround;
            _source.spatialBlend = 1;
            _source.minDistance = 0;
            _source.maxDistance = _soundDistance;
            _source.rolloffMode = AudioRolloffMode.Linear;
            _source.Play();
            yield break;
        }
    }
}
