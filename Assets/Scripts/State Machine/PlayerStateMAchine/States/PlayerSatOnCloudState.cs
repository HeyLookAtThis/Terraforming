using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class PlayerSatOnCloudState : State
{
    [SerializeField] private float _jumpForse;

    private Coroutine _jumper;

    private UnityAction _satOnCloud;

    public event UnityAction SatOnCloud
    {
        add => _satOnCloud += value;
        remove => _satOnCloud -= value;
    }

    private void OnEnable()
    {
        TakeJump();
    }

    private void TakeJump()
    {
        if (_jumper != null)
            StopCoroutine(_jumper);

        _jumper = StartCoroutine(JumpTaker());
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