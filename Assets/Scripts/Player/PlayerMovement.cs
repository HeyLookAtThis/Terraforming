using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _speed;

    private CharacterController _controller;

    public Vector3 Direction { get; private set; }

    public float Speed => _speed;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 direction = Vector3.zero;
        direction.x = _joystick.Horizontal * _speed * Time.deltaTime;
        direction.z = _joystick.Vertical * _speed * Time.deltaTime;

        Direction = direction;

        _controller.Move(Direction);
    }

    private void Rotate()
    {
        if (Direction != Vector3.zero)
            transform.forward = Direction;
    }
}
