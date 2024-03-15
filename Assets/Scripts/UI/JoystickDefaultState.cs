using UnityEngine;

[RequireComponent(typeof(FixedJoystick))]
public class JoystickDefaultState : MonoBehaviour
{
    [SerializeField] private LevelGenerator _levelGenerator;

    private FixedJoystick _fixed;

    private void Awake()
    {
        _fixed = GetComponent<FixedJoystick>();
    }

    private void OnEnable()
    {
        _levelGenerator.Launched += _fixed.OnFotmatInput;
    }

    private void OnDisable()
    {
        _levelGenerator.Launched -= _fixed.OnFotmatInput;
    }
}
