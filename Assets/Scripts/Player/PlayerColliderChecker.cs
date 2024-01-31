using UnityEngine;
using UnityEngine.Events;

public class PlayerColliderChecker : MonoBehaviour
{
    private Collider _previousCollider;

    private bool _grounded;

    private UnityAction _foundWater;

    public bool IsGrounded => _grounded;

    public event UnityAction FoundWater
    {
        add => _foundWater += value;
        remove => _foundWater -= value;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.TryGetComponent<Water>(out Water water))
        {
            _grounded = false;
            _foundWater?.Invoke();
        }

        if (_previousCollider != hit.collider)
        {
            if (hit.collider.TryGetComponent<Ground>(out Ground ground))
                _grounded = true;

            _previousCollider = hit.collider;
        }
    }
}
