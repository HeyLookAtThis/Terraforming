using UnityEngine;

public class CharacterLayerChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField] private LayerMask _water;

    [SerializeField, Range(0.01f, 1)] private float _distanceToCheck;

    public bool IsGrounded { get; private set; }
    public bool IsInWater {  get; private set; }

    private void Update()
    {
        IsGrounded = Physics.CheckSphere(transform.position, _distanceToCheck, _ground);
        IsInWater = Physics.CheckSphere(transform.position, _distanceToCheck, _water);
    }
}
