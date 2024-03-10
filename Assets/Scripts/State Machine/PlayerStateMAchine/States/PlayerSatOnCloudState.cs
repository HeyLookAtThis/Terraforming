using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerColliderChecker))]
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

    public void SatOnCloudInvoke()
    {
        _satOnCloud?.Invoke();
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

        float heightCounter = 0;
        float jumpTime = 0.3f;

        while (heightCounter < jumpTime)
        {
            heightCounter += Time.deltaTime;
            GetComponent<PlayerMovement>().MoveOnVertical(_jumpForse * Time.deltaTime);
            yield return waitTime;
        }

        if (heightCounter >= jumpTime)
        {
            _satOnCloud?.Invoke();
            yield break;
        }
    }
}
