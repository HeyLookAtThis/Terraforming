using UnityEngine;

[RequireComponent(typeof(FixedJoystick))]
public class JoystickDefaultState : MonoBehaviour
{
    private FixedJoystick _fixed;

    private void Awake()
    {
        _fixed = GetComponent<FixedJoystick>();
    }

    private void OnEnable()
    {
        _fixed.FotmatInput();
    }

    private void OnDisable()
    {
        _fixed.FotmatInput();
    }
}
