using DG.Tweening;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Volcano))]
public class VolcanoView : MonoBehaviour
{
    [SerializeField] private Color _iceColor;
    [SerializeField] private AudioClip _sound;

    [SerializeField] private ParticleSystem _smokeEffect;
    //[SerializeField] private ParticleSystem _freezeEffect;
    [SerializeField] private GameObject _model;
    
    private AudioSource _audioSourse;
    private MeshRenderer _renderer;
    private Coroutine _freezer;

    private void Awake()
    {
        _audioSourse = GetComponentInChildren<AudioSource>();
        _renderer = GetComponentInChildren<MeshRenderer>();
        _audioSourse.clip = _sound;
    }

    private void OnEnable()
    {
        GetComponent<Volcano>().WasFrozen += Freeze;
    }

    private void OnDisable()
    {
        GetComponent<Volcano>().WasFrozen -= Freeze;
    }

    public void PlaySmoke()
    {
        _smokeEffect.Play();
    }

    private void Freeze()
    {
        _audioSourse.Play();
        _smokeEffect.Stop();
        RunFreezer();
    }

    private void RunFreezer()
    {
        if (_freezer != null)
            StopCoroutine(_freezer);

        _freezer = StartCoroutine(Freezer());
    }

    private IEnumerator Freezer()
    {
        float second = 0.2f;
        var waitTime = new WaitForSeconds(second);

        float colorChangeSpeed = 2f;

        while (_renderer.material.color != _iceColor)
        {
            _renderer.material.DOColor(_iceColor, second * colorChangeSpeed);
            yield return waitTime;
        }

        if (_renderer.material.color == _iceColor)
            yield break;
    }
}
