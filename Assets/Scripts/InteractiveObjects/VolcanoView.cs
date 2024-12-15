using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VolcanoView : MonoBehaviour
{
    private const string SnowValue = "_Snow";
    private const string TranparentValue = "_TransVal";

    [SerializeField] private float _soundDistance;
    [SerializeField] private AudioClip _freezeSound;
    [SerializeField] private AudioClip _soundAround;

    [SerializeField] private ParticleSystem _smokeEffect;
    [SerializeField] private ParticleSystem _freezEffect;

    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Volcano _volcano;
    
    private AudioSource _source;
    private Coroutine _freezer;
    private Material _material;

    private float MinValueOfSpatialBlend => 0f;
    private float MaxValueOfSpatialBlend => 1f;

    private void Awake()
    {
        _source = GetComponentInChildren<AudioSource>();
        _material = _renderer.material;
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

        var waitTime = new WaitForEndOfFrame();

        float currensSnowValue = 1f;
        float targetSnowValue = 0.5f;

        float tranparentValue = 1f;
        float coroutineSpeed = 2f;

        bool isOver = false;

        while (isOver == false)
        {
            if (currensSnowValue > targetSnowValue)
            {
                currensSnowValue -= Time.deltaTime * coroutineSpeed;
                _material.SetFloat(SnowValue, currensSnowValue);
            }


            if (currensSnowValue <= targetSnowValue)
            {
                tranparentValue -= Time.deltaTime * coroutineSpeed;
                _material.SetFloat(TranparentValue, tranparentValue);

                if (tranparentValue <= 0)
                    isOver = true;
            }

            yield return waitTime;
        }

        if (isOver)
        {
            _volcano.ReturnToDefaultState();
            yield break;
        }
    }
}
