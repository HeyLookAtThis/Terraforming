using UnityEngine;

public class ForewardDirectionIndicator : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;

    private Vector3 TargetRotation => new Vector3(transform.rotation.x, transform.localRotation.y, 0);

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        transform.position = _targetTransform.position;
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Euler(TargetRotation);
    }
}
