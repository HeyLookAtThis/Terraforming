using UnityEngine;
using UnityEngine.Events;

public class PlayerColliderChecker : MonoBehaviour
{
    private Collider _previousCollider;

    private bool _grounded;

    private UnityAction _foundWater;
    private UnityAction _fellFromCloud;

    public bool IsGrounded => _grounded;

    public event UnityAction FoundWater
    {
        add => _foundWater += value;
        remove => _foundWater -= value;
    }

    public event UnityAction FellFromCloud
    {
        add => _fellFromCloud += value;
        remove => _fellFromCloud -= value;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.collider);

        if (hit.collider.TryGetComponent<Water>(out Water water))
        {
            _grounded = false;
            _foundWater?.Invoke();
        }

        if (_previousCollider != hit.collider || _previousCollider == null)
        {
            if (hit.collider.TryGetComponent<Ground>(out Ground ground))
                _grounded = true;

            if (!hit.collider.TryGetComponent<Cloud>(out Cloud cloud))
                _fellFromCloud?.Invoke();

            _previousCollider = hit.collider;
        }
    }
}
