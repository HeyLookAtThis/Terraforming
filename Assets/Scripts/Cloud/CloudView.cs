using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CloudView : MonoBehaviour
{
    [SerializeField] private Cloud _cloud;
    [SerializeField] private ParticleSystem _rainEffect;
    [SerializeField] private ParticleSystem _fillingUpEffect;
    [SerializeField] private AudioClip _rainSound;
    [SerializeField] private AudioClip _fillingUpSound;

    private AudioSource _audioSource;
    private Resizer _resizer;

    public Resizer Resizer => _resizer;
    private Scanner Scanner => _cloud.Scanner;
    private GrassPainter GrassPainter => _cloud.GrassPainter;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _resizer = new Resizer(_cloud.Config, _cloud.transform, this);

        SetDefaultState();
    }

    private void OnEnable()
    {
        Scanner.FoudWater += _resizer.OnStartIncrease;
        Scanner.LostWater += _resizer.OnStopIncrease;

        GrassPainter.Worked += _resizer.OnDecrease;
    }

    private void OnDisable()
    {
        Scanner.FoudWater -= _resizer.OnStartIncrease;
        Scanner.LostWater -= _resizer.OnStopIncrease;

        GrassPainter.Worked -= _resizer.OnDecrease;
    }

    public void SetDefaultState()
    {
        _resizer.SetDefault();
        _rainEffect.Stop();
        _fillingUpEffect.Stop();
        _audioSource.Stop();
    }

    public void PlayFillingUp()
    {
        StopEffect(_rainEffect);
        StartEffect(_fillingUpEffect);
    }

    public void PlayRain()
    {
        StopEffect(_fillingUpEffect);
        StartEffect(_rainEffect);
    }

    public void StopFillingUp() => StopEffect(_fillingUpEffect);
    public void StopRain() => StopEffect(_rainEffect);

    private void StartEffect(ParticleSystem effect)
    {
        if(effect.isPlaying == false)
        {
            effect.Play();

            if (effect == _fillingUpEffect)
                PlaySound(_fillingUpSound);
            else
                PlaySound(_rainSound);
        }
    }

    private void StopEffect(ParticleSystem effect)
    {
        if (effect.isPlaying)
        {
            effect.Stop();

            if (effect == _fillingUpEffect)
                StopSound(_fillingUpSound);
            else
                StopSound(_rainSound);
        }
    }

    private void StopSound(AudioClip audio)
    {
        if (_audioSource.clip == audio && _audioSource.isPlaying)
            _audioSource.Stop();
    }

    private void PlaySound(AudioClip audio)
    {
        if (_audioSource.clip != audio)
            _audioSource.clip = audio;

        if (_audioSource.isPlaying == false)
            _audioSource.Play();
    }
}
