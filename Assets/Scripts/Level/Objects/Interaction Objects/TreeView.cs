using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Tree))]
public class TreeView : ObjectSoundPlayer
{
    [SerializeField] private AudioClip _growSound;

    private ParticleSystem _particleSystem;
    private Tree _mainObject;

    protected override void Awake()
    {
        base.Awake();

        _mainObject = GetComponent<Tree>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _particleSystem.Stop();
    }

    protected override void OnEnable()
    {
        _mainObject.MadeGreen += Run;
    }

    protected override void OnDisable()
    {
        _mainObject.MadeGreen -= Run;
    }

    private void Start()
    {
        source.Stop();
    }

    private void Run()
    {
        PlaySound();
        _particleSystem.Play();
    }

    private void PlaySound()
    {
        source.loop = false;
        source.clip = _growSound;
        source.Play();

        StartCoroutine(SoundSwither());
    }

    private IEnumerator SoundSwither()
    {
        while (source.isPlaying)
        {
            yield return null;
        }

        if(!source.isPlaying)
        {
            source.clip = sound;
            source.loop = true;
            source.Play();
            yield break;
        }
    }
}
