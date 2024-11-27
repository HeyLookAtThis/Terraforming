using UnityEngine;
using UnityEngine.Events;

public class CharacterLayerChecker : MonoBehaviour
{
    private UnityAction _foundWater;
    private UnityAction _grounded;

    [SerializeField] private LayerMask _ground;
    [SerializeField] private LayerMask _water;

    [SerializeField, Range(0.01f, 1)] private float _distanceToCheck;

    public bool IsGrounded { get; private set; }
    public bool IsInWater {  get; private set; }


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

    private void Update()
    {
        IsGrounded = Physics.CheckSphere(transform.position, _distanceToCheck, _ground);
        IsInWater = Physics.CheckSphere(transform.position, _distanceToCheck, _water);

        if(IsInWater)
            _foundWater?.Invoke();

        if(IsGrounded)
            _grounded?.Invoke();
    }
}
