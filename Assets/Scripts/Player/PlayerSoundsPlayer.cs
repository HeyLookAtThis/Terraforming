using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSoundsPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _jumpOnCloudSound;
    [SerializeField] private AudioClip[] _stepSounds;

    private PlayerMoveOnGroundState _fellFromCloudState;
    private PlayerSatOnCloudState _jumpingState;
    private AudioSource _sourse;

    private void Awake()
    {
        _sourse = GetComponent<AudioSource>();

        _fellFromCloudState = GetComponentInParent<PlayerMoveOnGroundState>();
        _jumpingState = GetComponentInParent<PlayerSatOnCloudState>();
    }

    private void OnEnable()
    {
        _fellFromCloudState.Running += PlaySteps;
        _jumpingState.Jumping += PlayJump;
    }

    private void OnDisable()
    {
        _fellFromCloudState.Running -= PlaySteps;
        _jumpingState.Jumping -= PlayJump;
    }

    private void PlaySteps(float speed)
    {
        if (_sourse.isPlaying || speed == 0)
            return;

        int soundNumber = Random.Range(0, _stepSounds.Length);
        _sourse.clip = _stepSounds[soundNumber];
        _sourse.Play();
    }

    private void PlayJump()
    {
        _sourse.clip = _jumpOnCloudSound;
        _sourse.Play();
    }
}
