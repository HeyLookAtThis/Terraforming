using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Volcano))]
public class VolcanoView : MonoBehaviour
{
    private const string _CutoffValue = "_CutoffValue";

    [SerializeField] private AudioClip _freezeSound;

    [SerializeField] private ParticleSystem _smokeEffect;
    [SerializeField] private GameObject _model;
    
    private AudioSource _audioSourse;
    private Material _material;
    private Coroutine _freezer;

    private void Awake()
    {
        _audioSourse = GetComponentInChildren<AudioSource>();
        _material = GetComponentInChildren<MeshRenderer>().material;
    }

    private void OnEnable()
    {
        GetComponent<Volcano>().WasFrozen += Freeze;
    }

    private void OnDisable()
    {
        GetComponent<Volcano>().WasFrozen -= Freeze;
    }

    public void SetStartingEffectsState()
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
        _audioSourse.clip = _freezeSound;

        if (_freezer != null)
            StopCoroutine(_freezer);

        _freezer = StartCoroutine(Freezer());
    }

    private IEnumerator Freezer()
    {
        float second = 0.02f;
        var waitTime = new WaitForSecondsRealtime(second);

        float totalAlphaValue = 1f;
        float currentAlphaValue = 0;

        while (_material.GetFloat(_CutoffValue) < totalAlphaValue)
        {
            currentAlphaValue += second;
            _material.SetFloat(_CutoffValue, currentAlphaValue);
            yield return waitTime;
        }

        if (_material.GetFloat(_CutoffValue) == totalAlphaValue)
        {
            GetComponent<Volcano>().ReturnToDefaultState();
            yield break;
        }
    }
}
