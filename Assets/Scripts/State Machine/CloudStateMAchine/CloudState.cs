using UnityEngine;

public abstract class CloudState : State
{
    [SerializeField] private float _speedBoost;
    [SerializeField] protected Transform parentTransform;

    protected Vector3 positionIndent;
    protected Vector3 targetPosition;

    protected float speed;

    public float TargetSpeed => GetComponent<Cloud>().PlayerMovement.Speed;

    public Transform Target => GetComponent<Cloud>().PlayerMovement.transform;

    public override void Enter()
    {
        base.Enter();
        speed = TargetSpeed * _speedBoost;
    }

    protected void Move(Vector3 direction)
    {
        parentTransform.position = Vector3.MoveTowards(parentTransform.position, direction, speed * Time.deltaTime);
    }
}
