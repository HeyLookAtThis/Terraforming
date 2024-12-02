using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LootView : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;
    [SerializeField] private GameObject _model;

    private AudioSource _audioSourse;

    public bool IsAllowed => _model.activeSelf;

    private void Awake()
    {
        _audioSourse = GetComponent<AudioSource>();

        _audioSourse.clip = _sound;

        _audioSourse.playOnAwake = false;
        _audioSourse.loop = false;

        TurnOffVisible();
    }

    public void PlaySound()
    {
        _audioSourse.Play();
    }

    public void TurnOnVisible()
    {
        if (_model.activeSelf == false)
            _model.SetActive(true);
    }

    public void TurnOffVisible()
    {
        _model.SetActive(false);
    }
}
