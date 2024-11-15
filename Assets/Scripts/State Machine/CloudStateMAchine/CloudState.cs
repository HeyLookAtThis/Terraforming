using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(OldCloud))]
public abstract class CloudState : State
{
    [SerializeField] private float _speedBoost;

    protected Vector3 positionIndent;
    protected Vector3 targetPosition;

    protected float SpeedBoost => _speedBoost;

    public float TargetSpeed => 3f;

    public Transform Target => GetComponent<OldCloud>().Player.transform;

    protected void Move(Vector3 direction, float speed)
    {
        transform.DOMove(direction, speed);
    }
}
