using UnityEngine;

public class LootView : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;
    [SerializeField] private GameObject _model;

    private AudioSource _audioSourse;

    public bool IsAllowed => _model.activeSelf;

    public bool IsSoundPlaying => _audioSourse.isPlaying;

    private  void Awake()
    {
        _audioSourse = GetComponentInChildren<AudioSource>();

        _audioSourse.clip = _sound;

        _audioSourse.playOnAwake = false;
        _audioSourse.loop = false;
        gameObject.isStatic = false;

        TurnOffVisible();
    }

    public void PlaySound()
    {
        _audioSourse.Play();
    }

    public void TurnOnVisible()
    {
        if (!(_model.activeSelf))
            _model.SetActive(true);
    }

    public void TurnOffVisible()
    {
        _model.SetActive(false);
    }
}
