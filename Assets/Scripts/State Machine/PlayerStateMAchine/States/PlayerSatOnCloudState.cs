using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController), typeof(PlayerColliderChecker))]
public class PlayerSatOnCloudState : State
{
    [SerializeField] private float _jumpForse;

    private PlayerColliderChecker _colliderChecker;
    private Coroutine _jumper;

    private UnityAction _satOnCloud;
    private UnityAction _jumping;

    public event UnityAction SatOnCloud
    {
        add => _satOnCloud += value;
        remove => _satOnCloud -= value;
    }

    public event UnityAction Jumping
    {
        add => _jumping += value;
        remove => _jumping -= value;
    }

    private void Awake()
    {
        _colliderChecker = GetComponent<PlayerColliderChecker>();
    }

    private void OnEnable()
    {
        _colliderChecker.FoundWater += TakeJump;
    }

    private void OnDisable()
    {
        _colliderChecker.FoundWater -= TakeJump;
    }

    private void TakeJump()
    {
        if (_jumper != null)
            StopCoroutine(_jumper);

        _jumper = StartCoroutine(JumpTaker());

        _jumping?.Invoke();
    }

    private IEnumerator JumpTaker()
    {
        var waitTime = new WaitForEndOfFrame();

        Vector3 targetHeight = Vector3.up * _jumpForse;
        float heightCounter = 0;
        float jumpTime = 0.3f;

        while (heightCounter < jumpTime)
        {
            heightCounter += Time.deltaTime;
            GetComponent<CharacterController>().Move(targetHeight * Time.deltaTime);
            yield return waitTime;
        }

        if (heightCounter >= jumpTime)
        {
            _satOnCloud?.Invoke();
            yield break;
        }
    }
}
