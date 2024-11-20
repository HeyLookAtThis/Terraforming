using UnityEngine;
using UnityEngine.Events;

public class CharacterColliderChecker : MonoBehaviour
{
    private Collider _previousCollider;
    private UnityAction _foundWater;
    private UnityAction _grounded;

    public event UnityAction FoundWater
    {
        add => _foundWater += value;
        remove => _foundWater -= value;
    }

    public event UnityAction Grounded
    {
        add => _grounded += value;
        remove => _grounded -= value;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.TryGetComponent<Water>(out Water water))
            _foundWater?.Invoke();

        if (_previousCollider != hit.collider)
        {
            if (hit.collider.TryGetComponent<Ground>(out Ground ground))
                _grounded?.Invoke();

            _previousCollider = hit.collider;
        }
    }
}
