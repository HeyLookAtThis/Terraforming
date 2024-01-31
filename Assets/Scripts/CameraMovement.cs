using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private Vector3 _interval;

    private float _speed = 10;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position + _interval, _speed * Time.deltaTime);
    }
}
