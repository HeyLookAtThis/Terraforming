using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Cloud))]
public abstract class CloudState : State
{
    [SerializeField] private float _speedBoost;

    protected Vector3 positionIndent;
    protected Vector3 targetPosition;

    protected float SpeedBoost => _speedBoost;

    public float TargetSpeed => GetComponent<Cloud>().PlayerMovement.Speed;

    public Transform Target => GetComponent<Cloud>().Player.transform;

    protected void Move(Vector3 direction, float speed)
    {
        transform.DOMove(direction, speed);
    }
}
