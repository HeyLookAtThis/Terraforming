using UnityEngine;
using UnityEngine.Events;

public class CharacterColliderChecker : MonoBehaviour
{
    private bool _grounded;
    private bool _isInWater;

    private Collider _previousCollider;
    private UnityAction _foundWater;

    public event UnityAction FoundWater
    {
        add => _foundWater += value;
        remove => _foundWater -= value;
    }

    public bool CheckGrounded() => _grounded || _isInWater;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.TryGetComponent<Water>(out Water water))
        {
            _isInWater = true;
            _grounded = false;
            _foundWater?.Invoke();
        }
        else
        {
            _isInWater = false;
        }

        if (_previousCollider != hit.collider)
        {
            if (hit.collider.TryGetComponent<Ground>(out Ground ground))
                _grounded = true;

            _previousCollider = hit.collider;
        }
    }
}
