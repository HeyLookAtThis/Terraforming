using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _controller;
    private FixedJoystick _joystick;

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

    public void InitializeJoystic(FixedJoystick joystick)
    {
        _joystick = joystick;
    }

    public void MoveOnVertical(float forse)
    {
        _controller.Move(Vector3.up * forse);
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
