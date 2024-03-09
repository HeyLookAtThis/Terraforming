using UnityEngine;

[RequireComponent(typeof(FixedJoystick))]
public class JoystickDefaultState : MonoBehaviour
{
    [SerializeField] private Ground _ground;

    private FixedJoystick _fixed;

    private void Awake()
    {
        _fixed = GetComponent<FixedJoystick>();
    }

    private void OnEnable()
    {
        _ground.Overheated += _fixed.OnFotmatInput;
    }

    private void OnDisable()
    {
        _ground.Overheated -= _fixed.OnFotmatInput;
    }
}
