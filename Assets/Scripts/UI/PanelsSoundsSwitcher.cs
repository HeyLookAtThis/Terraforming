using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(PanelsSwitcher))]
public class PanelsSoundsSwitcher : MonoBehaviour
{
    [SerializeField] private AudioClip _menuSound;
    [SerializeField] private AudioClip _gameSound;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private AudioClip _gameOverSound;

    private PanelsSwitcher _mainController;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _mainController = GetComponent<PanelsSwitcher>();
        _audioSource.loop = true;
        _audioSource.volume = 0.5f;
        _audioSource.playOnAwake = false;
    }

    private void OnEnable()
    {
        _mainController.ChangedPanel += PlaySound;
    }

    private void OnDisable()
    {
        _mainController.ChangedPanel += PlaySound;
    }

    private void PlaySound(Panel panel)
    {
        switch(panel)
        {
            case TitlePanel:
                _audioSource.clip = _menuSound;
                break;

            case MenuPanel:
                _audioSource.clip = _menuSound;
                break;

            case LoadingPanel:
                _audioSource.clip = _menuSound;
                break;

            case GamePanel:
                _audioSource.clip = _gameSound;
                break;

            case GameOverPanel:
                _audioSource.clip = _gameOverSound;
                break;

            case WinPanel:
                _audioSource.clip = _winSound;
                break;
        }

        if(!_audioSource.isPlaying)
            _audioSource.Play();
    }
}
